using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Fighting : MonoBehaviour
{
    public PrepareFight Prepare;
    public FightChanges Change;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// UPDATE => HERO HP / MONSTER HP / MONSTER NAME /
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        if (Prepare.Next.Connector.GoGoFight == true)
        {
            Prepare.ImageTextsToFight.OnStart();
            Prepare.ImageTextsToFight.HeroHpText.text = Prepare.MyHero.hero.HitPoints.ToString();
            Prepare.ImageTextsToFight.MonsterHpText.text = Prepare.MyMonsters.allMonsters
                .MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.Next.Connector.ChoseMonster].HitPoints.ToString();
            Prepare.ImageTextsToFight.MonsterNameText.text =
                Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.Next.Connector.ChoseMonster].Name;

            Prepare.Next.Connector.GoGoFight = false;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// FIRST ACCEPT FIGHT WITH BUTTON AND NEXT START COROUTUINE
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void AcceptToFight()
    {
        StartFight();
    }

    void StartFight()
    {
        StartCoroutine(FightMain());
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// MAIN FIGHTING SCRIPT ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public IEnumerator FightMain()
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Preparation for Battle
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        if (Prepare.IsFighting == false)
        {
            if (Prepare.Next.Connector.RandomFight == true)
                Prepare.LosulosuMonster();
            else
            {
                Prepare.RandomMonster = Prepare.Next.Connector.ChoseMonster;
            }

            Prepare.PreFight();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// MAIN LOOP FIGHT
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        while (true)
        {

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// 1.Change Text during the game /// 2. Random sign on the screan ///
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Change.TextInGame(); // 1
            Change.RandomSign(); // 2

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// HERO TURN
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (Prepare.HeroTurn == true && Prepare.ChangeTurn == true && Prepare.EndOfCombo_Only_one == false)
            {
                while (true)
                {
                    Prepare.Timer -= Time.deltaTime;
                    if (Prepare.RandomButton == Prepare.NumberOfButton) /// Good touch Combo ++
                    {
                        Prepare.ImageTextsToFight.GoodPanel.enabled = true;
                        yield return new WaitForSeconds(0.2f);
                        Prepare.ImageTextsToFight.GoodPanel.enabled = false;
                        Change.ResetCombo_Hero();
                        break;
                    }
                    if (((Prepare.RandomButton != Prepare.NumberOfButton) && Prepare.CanITap == false && Prepare.NumberOfButton != 0) || Prepare.Timer <= 0) // Bad touch Combo Ends
                    {
                        if (Prepare.Timer >= 0)
                        {
                            Prepare.ImageTextsToFight.BadPanel.enabled = true;
                            yield return new WaitForSeconds(0.2f);
                            Prepare.ImageTextsToFight.BadPanel.enabled = false;
                        }

                        Change.CalculateDMG_Hero();
                        Change.ResetBattle_Hero();
                        if (Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].HitPoints > 0)
                            break;
                    }
                    if (Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].HitPoints <= 0) // Hero beat Monster
                    {
                        Change.EndBattle();
                        break;
                    }
                    yield return null;
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// MONSTER TURN
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (Prepare.HeroTurn == false && Prepare.ChangeTurn == true && Prepare.EndOfCombo_Only_one == false
                && Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].HitPoints > 0)
            {
                while (true)
                {
                    Prepare.Timer -= Time.deltaTime;
                    if (Prepare.RandomButton == Prepare.NumberOfButton) // Monster miss Hero
                    {
                        Prepare.ImageTextsToFight.GoodPanel.enabled = true;
                        yield return new WaitForSeconds(0.2f);
                        Prepare.ImageTextsToFight.GoodPanel.enabled = false;
                        Change.ResetCombo_Monster();
                        break;
                    }
                    else if (((Prepare.RandomButton != Prepare.NumberOfButton) && Prepare.CanITap == false && Prepare.NumberOfButton != 0) || Prepare.Timer <= 0) // Monster hit Hero
                    {
                        if (Prepare.Timer >= 0)
                        {
                            Prepare.ImageTextsToFight.BadPanel.enabled = true;
                            yield return new WaitForSeconds(0.2f);
                            Prepare.ImageTextsToFight.BadPanel.enabled = false;
                        }
                        Change.CalculateDMG_Monster();
                        Change.ResetCombo_Monster();
                        if (Prepare.MyHero.hero.HitPoints > 0)
                            break;
                    }

                    if (Prepare.MyHero.hero.HitPoints <= 0) // Monster beat Hero Game Over
                    {
                        Prepare.EndOfCombo_All = true;
                        Prepare.IsFighting = false;
                        Change.ResetBattle_Monster();
                        Change.HeroDead();
                        break;
                    }

                    if (Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].HitAttack < Prepare.MonsterRoundNumber) // Ends monsters attack
                    {
                        Change.ResetCombo_Monster();
                        Change.ResetBattle_Monster();
                        Prepare.MonsterRoundNumber--;
                        break;
                    }
                    yield return null;
                }
                Prepare.MonsterRoundNumber++;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// REST OF CHECKS /// End or change turn ///
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Change.TextInGame();
            Change.EndOfWhile_Hero();

            if (Prepare.EndOfCombo_All == true)
            {
                Prepare.EndOfCombo_All = false;
                Prepare.ImageTextsToFight.MonsterAttackLeftText.enabled = false;
                break;
            }

            if (Prepare.ChangeTurn == false)
            {
                yield return new WaitForSeconds(3);
               Change.AfterWaitForS();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Waiting for player when click contiune button /// Next Reset Fight and go to Village or Mountain
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        while (true)
        {
            if (Prepare.ClickEnd == true)
            {
                break;
            }
            yield return null;
        }
        Prepare.ResetFight();
        if (Prepare.Next.Connector.GoBoss == true)
            Prepare.GoToVillage();
        else
            Prepare.GoToMountain();
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
