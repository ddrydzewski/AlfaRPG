using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightChanges : MonoBehaviour
{
    public PrepareFight Prepare;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// RANDOM SIGN ALL SHAPE AND COLOR ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void RandomSign()
    {
        if (Prepare.EndOfCombo_Only_one == true)
        {
            // Random Color and random Shape
            Prepare.RandomButton = Random.Range(1, 5); // 1 Circle // 2 Triangle // 3 Square // 4 Deltoid
            Prepare.RandomColor = Random.Range(1, 5); // 1 Blue // 2 Green // 3 Yellow // 4 Brown

            if (Prepare.RandomButton == 1)
            {
                if (Prepare.RandomColor == 1)
                    Prepare.ImageTextsToFight.CircleBlueImage.enabled = true;
                else if (Prepare.RandomColor == 2)
                    Prepare.ImageTextsToFight.CircleGreenImage.enabled = true;
                else if (Prepare.RandomColor == 3)
                    Prepare.ImageTextsToFight.CircleYellowImage.enabled = true;
                else if (Prepare.RandomColor == 4)
                    Prepare.ImageTextsToFight.CircleBrownImage.enabled = true;
            }

            if (Prepare.RandomButton == 2)
            {
                if (Prepare.RandomColor == 1)
                    Prepare.ImageTextsToFight.TriangleBlueImage.enabled = true;
                else if (Prepare.RandomColor == 2)
                    Prepare.ImageTextsToFight.TriangleGreenImage.enabled = true;
                else if (Prepare.RandomColor == 3)
                    Prepare.ImageTextsToFight.TriangleYellowImage.enabled = true;
                else if (Prepare.RandomColor == 4)
                    Prepare.ImageTextsToFight.TriangleBrownImage.enabled = true;
            }

            if (Prepare.RandomButton == 3)
            {
                if (Prepare.RandomColor == 1)
                    Prepare.ImageTextsToFight.SquareBlueImage.enabled = true;
                else if (Prepare.RandomColor == 2)
                    Prepare.ImageTextsToFight.SquareGreenImage.enabled = true;
                else if (Prepare.RandomColor == 3)
                    Prepare.ImageTextsToFight.SquareYellowImage.enabled = true;
                else if (Prepare.RandomColor == 4)
                    Prepare.ImageTextsToFight.SquareBrownImage.enabled = true;
            }

            if (Prepare.RandomButton == 4)
            {
                if (Prepare.RandomColor == 1)
                    Prepare.ImageTextsToFight.DeltoidBlueImage.enabled = true;
                else if (Prepare.RandomColor == 2)
                    Prepare.ImageTextsToFight.DeltoidGreenImage.enabled = true;
                else if (Prepare.RandomColor == 3)
                    Prepare.ImageTextsToFight.DeltoidYellowImage.enabled = true;
                else if (Prepare.RandomColor == 4)
                    Prepare.ImageTextsToFight.DeltoidBrownImage.enabled = true;
            }

            Prepare.EndOfCombo_Only_one = false;

        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// RESET HERO ONE COMBO WHEN PLAYER HIT GOOD TARGET
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ResetCombo_Hero()
    {
        Prepare.ImageTextsToFight.OffRandomImages();

        Prepare.EndOfCombo_Only_one = true;
        Prepare.CanITap = true;

        Prepare.NumberOfButton = 0;
        Prepare.ComboPoints++;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// RESET HERO ENTIRE COMBO
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ResetBattle_Hero()
    {
        Prepare.ImageTextsToFight.OffRandomImages();

        /////////////////////////////////
        /// Quest1_1 ///
        /////////////////////////////////

        if (Prepare.ComboPoints >= 8 && Prepare.Quests.AllQuests.QuestList[0][0].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 0)
        {
            Prepare.Quests.AllQuests.QuestList[0][0].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[0][0].Save = 1;
        }

        /////////////////////////////////
        /// Quest2_4 ///
        /////////////////////////////////

        if (Prepare.ComboPoints >= 9 && Prepare.Quests.AllQuests.QuestList[1][3].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 1)
        {
            Prepare.Quests.AllQuests.QuestList[1][3].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[1][3].Save = 1;
        }

        /////////////////////////////////
        /// Quest2_4 ///
        /////////////////////////////////

        if (Prepare.ComboPoints < 5 && Prepare.Next.Connector.WhichCastle >= 1)
        {
            Prepare.Quests.Quest2_3_6Combo = false;
        }

        Prepare.EndOfCombo_Only_one = true;
        Prepare.CanITap = true;
        Prepare.HeroTurn = false;
        Prepare.ChangeTurn = false;

        Prepare.WaitingForPlayer = 1.9f;
        Prepare.Timer = Prepare.WaitingForPlayer;
        Prepare.RoundNumber = 0;
        Prepare.NumberOfButton = 0;
        Prepare.ImageTextsToFight.MinusHeroText.enabled = true;
        if (Prepare.MyHero.hero.DamageDealt != 0 || Prepare.ComboPoints != 0)
            Prepare.ImageTextsToFight.MinusHeroText.text = "-" + Prepare.MyHero.hero.DamageDealt.ToString();
        if (Prepare.MyHero.hero.DamageDealt == 0)
            Prepare.ImageTextsToFight.MinusHeroText.text = "0 Heh";
        Prepare.ComboPoints = 0;


    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// RESET ONE MONSER COMBO
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ResetCombo_Monster()
    {
        Prepare.ImageTextsToFight.OffRandomImages();

        Prepare.CanITap = true;
        Prepare.EndOfCombo_Only_one = true;

        Prepare.NumberOfButton = 0;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// RESET MONSTER ENTIRE COMBO
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ResetBattle_Monster()
    {
        Prepare.ImageTextsToFight.OffRandomImages();

        Prepare.CanITap = true;
        Prepare.HeroTurn = true;
        Prepare.EndOfCombo_Only_one = true;
        Prepare.ChangeTurn = false;
        Prepare.ImageTextsToFight.MonsterAttackLeftText.gameObject.SetActive(false);

        Prepare.WaitingForPlayer = 1.9f;
        Prepare.Timer = Prepare.WaitingForPlayer;
        Prepare.NumberOfButton = 0;
        Prepare.RoundNumber = 0;
        Prepare.MonsterRoundNumber = 1;

        Prepare.ImageTextsToFight.MinusMonsterText.enabled = true;
        if (Prepare.MonsterDamageDealt != 0)
            Prepare.ImageTextsToFight.MinusMonsterText.text = "-" + Prepare.MonsterDamageDealt.ToString();
        if (Prepare.MonsterDamageDealt == 0)
            Prepare.ImageTextsToFight.MinusMonsterText.text = "Clean!";
        Prepare.MonsterDamageDealt = 0;

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// EVERY COMBO SPEEDS UP NEXT COMBO /// Player have less time /// 
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void EndOfWhile_Hero()
    {
        Prepare.WaitingForPlayer = Prepare.WaitingForPlayer - Prepare.WaitingForPlayer / 6;
        Prepare.Timer = Prepare.WaitingForPlayer;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// CALCULATE DAMAGE HERO | HERO ATTACK MONSTER| /// CALCULATE DAMAGE MONSTER | MONSTER ATTACK HERO| ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void CalculateDMG_Hero()
    {

        if (((Prepare.MyHero.hero.Damage * Prepare.ComboPoints) >
            Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].Armor / 2) && Prepare.ComboPoints != 0)
        {

            Prepare.MyHero.hero.DamageDealt = (Prepare.MyHero.hero.Damage * Prepare.ComboPoints) -
                                              Prepare.MyMonsters.allMonsters.MonsterList[
                                                  Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].Armor / 2;

            Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster]
                .HitPoints -= Prepare.MyHero.hero.DamageDealt;
        }
    }

    public void CalculateDMG_Monster()
    {
        if (Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].Damage + Prepare.HowMuchHitMe
            > (Prepare.MyHero.hero.Armor / 4))
        {
            Prepare.MyHero.hero.HitPoints -= (Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].Damage
                                              + Prepare.HowMuchHitMe) - (Prepare.MyHero.hero.Armor / 4);
            Prepare.MonsterDamageDealt += (Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].Damage
                                           + Prepare.HowMuchHitMe) - (Prepare.MyHero.hero.Armor / 4);
        }

        Prepare.HowMuchHitMe++;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// MANAGMENT OF TEXT DURING FIGHT
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void TextInGame()
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// MANAGMENT OF TEXT DURING FIGHT
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Prepare.HeroTurn == true)
        {
            Prepare.ImageTextsToFight.ComboPointsText.enabled = true;
            Prepare.ImageTextsToFight.ComboPointsText.GetComponent<Text>().text = "x" + Prepare.ComboPoints.ToString();
            Prepare.ImageTextsToFight.WhoseTurnText.text = "ATTACK";
            Prepare.ImageTextsToFight.WhoseTurnText.color = Color.red;
            Prepare.ImageTextsToFight.ComboPointsText.gameObject.SetActive(true);
        }
        if (Prepare.ComboPoints > Prepare.ComboPointsChange)
        {
            Prepare.ComboPointsChange = Prepare.ComboPoints;
            Prepare.ImageTextsToFight.ComboPointsText.fontSize += 20;
        }

        Prepare.ImageTextsToFight.HeroHpText.GetComponent<Text>().text = Prepare.MyHero.hero.HitPoints.ToString();
        Prepare.ImageTextsToFight.MonsterHpText.GetComponent<Text>().text = Prepare.MyMonsters.allMonsters
            .MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].HitPoints.ToString();
        Prepare.ImageTextsToFight.MonsterNameText.GetComponent<Text>().text =
            Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].Name;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// MANAGMENT OF TEXT DURING FIGHT
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Prepare.HeroTurn == false)
        {
            Prepare.ImageTextsToFight.WhoseTurnText.text = "DEFENCE";
            Prepare.ImageTextsToFight.WhoseTurnText.color = Color.blue;
            Prepare.ImageTextsToFight.MonsterAttackLeftText.GetComponent<Text>().text =
                "Left: " + Prepare.MonsterRoundNumber.ToString() + "/" +
                Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].HitAttack.ToString();
            Prepare.ImageTextsToFight.MonsterAttackLeftText.enabled = true;
            Prepare.ImageTextsToFight.MonsterAttackLeftText.gameObject.SetActive(true);

        }

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ON END BATTLE ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void EndBattle()
    {
        Prepare.MyHero.hero.Experience += Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].ExpGive;
        Prepare.ImageTextsToFight.WinBattleText.enabled = true;
        Prepare.EndOfCombo_All = true;
        Prepare.IsFighting = false;
        Prepare.GoldGive = Random.Range(0 + Prepare.MyHero.hero.GlovesSet * 2,
            Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].GoldGive + Prepare.MyHero.hero.GlovesSet * 2);
        Prepare.MyHero.hero.Gold += Prepare.GoldGive;

        Prepare.ImageTextsToFight.ExpGiveText.enabled = true;
        Prepare.ImageTextsToFight.ExpGiveText.text = "Exp :" + Prepare.MyMonsters.allMonsters
            .MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].ExpGive.ToString();

        Prepare.ImageTextsToFight.GoldGiveText.enabled = true;
        Prepare.ImageTextsToFight.GoldGiveText.text = "Gold: " + Prepare.GoldGive.ToString();

        Prepare.ImageTextsToFight.HeroHpText.enabled = false;
        Prepare.ImageTextsToFight.MonsterHpText.enabled = false;
        Prepare.ImageTextsToFight.MonsterAttackLeftText.enabled = false;
        Prepare.ImageTextsToFight.WhoseTurnText.enabled = false;

        Prepare.ImageTextsToFight.TriangleTouch.enabled = false;
        Prepare.ImageTextsToFight.CircleTouch.enabled = false;
        Prepare.ImageTextsToFight.DeltoidTouch.enabled = false;
        Prepare.ImageTextsToFight.SquareTouch.enabled = false;

        Prepare.ImageTextsToFight.ContinuePanel.enabled = true;
        Prepare.ImageTextsToFight.RandomPanel.enabled = false;

        Prepare.ImageTextsToFight.WinBattleText.enabled = true;
        Prepare.ImageTextsToFight.WinOverPanel.enabled = true;
        Prepare.ImageTextsToFight.ComboPointsText.enabled = false;

        if (Prepare.MyHero.hero.Experience > Prepare.MyHero.hero.ExpList[Prepare.MyHero.hero.HeroLevel - 1])
        {
            Prepare.MyHero.hero.HeroLevel++;
            Prepare.MyHero.hero.LevelPoints += 5;
            Prepare.ImageTextsToFight.LvlUpText.enabled = true;
            Prepare.ImageTextsToFight.LvlPanel.enabled = true;
        }

        /////////////////////////////////
        /// Quest1_2 ///
        /////////////////////////////////

        if (Prepare.MyHero.hero.HitPoints == (Prepare.MyHero.hero.Vitality * 10) && Prepare.Quests.AllQuests.QuestList[0][1].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 0)
        {
            Prepare.Quests.AllQuests.QuestList[0][1].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[0][1].Save = 1;
        }

        /////////////////////////////////
        /// Quest1_5 ///
        /////////////////////////////////

        if (Prepare.MyMonsters.allMonsters.MonsterList[0][0].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[0][1].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[0][2].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[0][3].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[0][4].BeatCounter >= 5 && Prepare.Quests.AllQuests.QuestList[0][4].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 0)
        {
            Prepare.Quests.AllQuests.QuestList[0][4].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[0][4].Save = 1;
        }

        /////////////////////////////////
        /// Quest2_1 ///
        /////////////////////////////////

        if (Prepare.MyMonsters.allMonsters.MonsterList[1][0].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[1][1].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[1][2].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[1][3].BeatCounter >= 5
            && Prepare.MyMonsters.allMonsters.MonsterList[1][4].BeatCounter >= 5 && Prepare.Quests.AllQuests.QuestList[1][4].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 1)
        {
            Prepare.Quests.AllQuests.QuestList[1][0].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[1][0].Save = 1;
        }

        /////////////////////////////////
        /// Quest2_2 ///
        /////////////////////////////////

        if (Prepare.MyHero.hero.HitPoints == (Prepare.MyHero.hero.Vitality * 10) && Prepare.Quests.AllQuests.QuestList[1][1].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 1)
        {
            Prepare.Quests.Quest2_2_Battle++;

            if (Prepare.Quests.Quest2_2_Battle > 1)
            {
                Prepare.Quests.AllQuests.QuestList[1][1].QuestComplete = true;
                Prepare.Quests.AllQuests.QuestList[1][1].Save = 1;
            }

        }

        /////////////////////////////////
        /// Quest2_5 ///
        /////////////////////////////////

        if (Prepare.Quests.Quest2_5_Random > 9 && Prepare.Quests.AllQuests.QuestList[1][4].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 1)
        {
            Prepare.Quests.AllQuests.QuestList[1][4].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[1][4].Save = 1;
        }

        /////////////////////////////////
        /// Quest2_3 ///
        /////////////////////////////////

        if (Prepare.Quests.Quest2_3_6Combo == true && Prepare.Quests.AllQuests.QuestList[1][2].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 1)
        {
            Prepare.Quests.AllQuests.QuestList[1][2].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[1][2].Save = 1;
        }

        /////////////////////////////////
        /// Quest3_1 ///
        /////////////////////////////////

        if (Prepare.MyMonsters.allMonsters.MonsterList[2][0].BeatCounter >= 4
            && Prepare.MyMonsters.allMonsters.MonsterList[2][1].BeatCounter >= 4
            && Prepare.MyMonsters.allMonsters.MonsterList[2][2].BeatCounter >= 4
            && Prepare.MyMonsters.allMonsters.MonsterList[2][3].BeatCounter >= 4
            && Prepare.MyMonsters.allMonsters.MonsterList[2][4].BeatCounter >= 4 && Prepare.Quests.AllQuests.QuestList[2][4].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 2)
        {
            Prepare.Quests.AllQuests.QuestList[2][1].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[2][1].Save = 1;
        }

        /////////////////////////////////
        /// Quest3_5 ///
        /////////////////////////////////

        if (Prepare.MyMonsters.allMonsters.MonsterList[2][4].BeatCounter >= 10 && Prepare.Quests.AllQuests.QuestList[2][4].QuestComplete != true && Prepare.Next.Connector.WhichCastle >= 2)
        {
            Prepare.Quests.AllQuests.QuestList[2][4].QuestComplete = true;
            Prepare.Quests.AllQuests.QuestList[2][4].Save = 1;
        }

        Prepare.Quests.Quest2_3_6Combo = true;
        Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].BeatCounter++;
        Prepare.ContinueButton.enabled = true;
        Prepare.ContinueButton.gameObject.SetActive(true);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// THING AFTER HERO DEFEAT ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    public void HeroDead()
    {
        Prepare.ImageTextsToFight.GameOverText.enabled = true;

        Prepare.ImageTextsToFight.HeroHpText.enabled = false;
        Prepare.ImageTextsToFight.MonsterHpText.enabled = false;
        Prepare.ImageTextsToFight.MonsterAttackLeftText.enabled = false;
        Prepare.ImageTextsToFight.WhoseTurnText.enabled = false;
        Prepare.ImageTextsToFight.MinusMonsterText.enabled = false;

        Prepare.ImageTextsToFight.TriangleTouch.enabled = false;
        Prepare.ImageTextsToFight.CircleTouch.enabled = false;
        Prepare.ImageTextsToFight.DeltoidTouch.enabled = false;
        Prepare.ImageTextsToFight.SquareTouch.enabled = false;

        Prepare.ImageTextsToFight.ContinuePanel.enabled = true;
        Prepare.ImageTextsToFight.RandomPanel.enabled = false;

        Prepare.ImageTextsToFight.WinOverPanel.enabled = true;
        Prepare.ImageTextsToFight.ComboPointsText.enabled = false;

        Prepare.ContinueButton.enabled = true;
        Prepare.ContinueButton.gameObject.SetActive(true);

        if (Prepare.MyHero.hero.Experience >
            Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster]
                .ExpGive)
        {
            Prepare.ImageTextsToFight.ExpGiveText.enabled = true;
            Prepare.MyHero.hero.Experience -=
                Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster]
                    .ExpGive;

            Prepare.ImageTextsToFight.ExpGiveText.text = "Exp : - " + Prepare.MyMonsters.allMonsters
                                                             .MonsterList[Prepare.Next.Connector.WhichCastle][
                                                                 Prepare.RandomMonster].ExpGive.ToString();
        }

        if (Prepare.MyHero.hero.Gold > Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster].GoldGive)
        {
            Prepare.MyHero.hero.Gold -=
                Prepare.MyMonsters.allMonsters.MonsterList[Prepare.Next.Connector.WhichCastle][Prepare.RandomMonster]
                    .GoldGive;

            Prepare.ImageTextsToFight.GoldGiveText.enabled = true;
            Prepare.ImageTextsToFight.GoldGiveText.text = "Gold: - " + Prepare.GoldGive.ToString();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// AFTER WAIT FOR SECONDS ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void AfterWaitForS()
    {
        Prepare.ImageTextsToFight.MinusHeroText.enabled = false;
        Prepare.ImageTextsToFight.MinusMonsterText.enabled = false;
        Prepare.ImageTextsToFight.ComboPointsText.gameObject.SetActive(false);
        Prepare.ImageTextsToFight.ComboPointsText.fontSize = 200;
        Prepare.MyHero.hero.DamageDealt = 0;
        Prepare.ChangeTurn = true;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
