using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Transform CameraTransform;
    public Connector Connector;
    public MonsterObject Monster;
    public HeroObject Hero;

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // MENU --> MOUNTAIN --> SKILLS --> ITEMSHOP --> EXIT --> QUESTS //  
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Village_BigMountain()
    {
        Connector.BigMountain = true;
        CameraTransform.position = new Vector3(507, 7873, -50);
    }

    public void Village_Skills()
    {
        Connector.Skills = true;
        CameraTransform.position = new Vector3(-5505, 7975, -50);
    }

    public void Village_ItemShop()
    {
        Connector.ForgeUp = true;
        CameraTransform.position = new Vector3(-2499, 7953, -50);
    }

    public void Village_Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Village_Quests()
    {
        Connector.Quests = true;
        Connector.QuestScene = 4;
        CameraTransform.position = new Vector3(-5495, -81, -50);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // LARP QUESTS
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Quests_Floor1()
    {
        Connector.QuestScene = 1;
    }

    public void Quests_Floor2()
    {
        if (Monster.allMonsters.MonsterList[0][5].BeatCounter > 0)
        Connector.QuestScene = 2;
    }

    public void Quests_Floor3()
    {
        if (Monster.allMonsters.MonsterList[1][5].BeatCounter > 0)
            Connector.QuestScene = 3;
    }

    public void Quests_BackToQuest()
    {
        Connector.QuestScene = 4;
    }

    void Update()
    {
        if (Connector.Quests == true)
        {
            if (Connector.QuestScene == 1)
            {
                CameraTransform.position = Vector3.Lerp(CameraTransform.position, Connector.Quests1, 0.15f);
            }

            if (Connector.QuestScene == 2)
            {
                CameraTransform.position = Vector3.Lerp(CameraTransform.position, Connector.Quests2, 0.15f);
            }

            if (Connector.QuestScene == 3)
            {
                CameraTransform.position = Vector3.Lerp(CameraTransform.position, Connector.Quests3, 0.15f);
            }

            if (Connector.QuestScene == 4)
            {
                CameraTransform.position = Vector3.Lerp(CameraTransform.position, Connector.QuestsMain, 0.15f);
            }
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // BACK TO VILLAGE // BACK TO MOUNTAIN // 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Back_To_Village()
    {
        Connector.Skills = false;
        Connector.BigMountain = false;
        Connector.ForgeUp = false;
        Connector.Quests = false;
        CameraTransform.position = new Vector3(-8478, 7986, -50);
    }

    public void Back_To_BigMountain()
    {
        Connector.Castle_1 = false;
        Connector.Castle_2 = false;
        Connector.Castle_3 = false;
        CameraTransform.position = new Vector3(507, 7873, -50);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // GO TO CASTLE // 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void BigMountain_Castle1()
    {
        Connector.Castle_1 = true;
        Connector.WhichCastle = 0;
        CameraTransform.position = new Vector3(-8480, 3861, -50);
    }

    public void BigMountain_Castle2()
    {
        if (Monster.allMonsters.MonsterList[0][5].BeatCounter == 1)
        {
            Connector.WhichCastle = 1;
            Connector.Castle_2 = true;
            CameraTransform.position = new Vector3(-2485, 3884, -50);
        }
    }

    public void BigMountain_Castle3()
    {
        if (Monster.allMonsters.MonsterList[1][5].BeatCounter == 1)
        {
            Connector.WhichCastle = 2;
            Connector.Castle_3 = true;
            CameraTransform.position = new Vector3(3526, 3893, -50);
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // WHICH MONSTER // 
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void WIND_FightScene_Monster1()
    {
        Connector.ChoseMonster = 0;
        TravelToFight();
    }

    public void WIND_FightScene_Monster2()
    {
        Connector.ChoseMonster = 1;
        TravelToFight();
    }

    public void WIND_FightScene_Monster3()
    {
        Connector.ChoseMonster = 2;
        TravelToFight();
    }

    public void WIND_FightScene_Monster4()
    {
        Connector.ChoseMonster = 3;
        TravelToFight();
    }

    public void WIND_FightScene_Monster5()
    {
        Connector.ChoseMonster = 4;
        TravelToFight();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // BOSSES //
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void WIND_FightScene_Boss1()
    {
        Connector.GoBoss = true;
        TravelToFight();      
    }

    public void WIND_FightScene_Boss2()
    {
        Connector.GoBoss = true;
        TravelToFight();
    }

    public void WIND_FightScene_Boss3()
    {
        Connector.GoBoss = true;
        TravelToFight();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void Boss1()
    {
        if (Hero.hero.HeroLevel > 5 && Monster.allMonsters.MonsterList[0][5].BeatCounter == 0)
        {
            Connector.ChoseMonster = 5;
            CameraTransform.position = new Vector3(-5472, 3851, -50);
        }
    }

    public void Boss2()
    {
        if (Hero.hero.HeroLevel > 11 && Monster.allMonsters.MonsterList[1][5].BeatCounter == 0)
        {
            Connector.ChoseMonster = 5;
            CameraTransform.position = new Vector3(521, 3874, -50);
        }
    }

    public void Boss3()
    {
        if (Hero.hero.HeroLevel > 17 && Monster.allMonsters.MonsterList[2][5].BeatCounter == 1)
        {
            Connector.ChoseMonster = 5;
            CameraTransform.position = new Vector3(6540, 3894, -50);
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // FIGHT // RANDOM // TUTORIAL //
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void TravelToFight()
    {
        Connector.GoGoFight = true;

        if (Hero.hero.NewGame == 0)
        {
            Hero.hero.NewGame = 1;
            CameraTransform.position = new Vector3(6393, 7861, -50);
        }
        else
        {
            CameraTransform.position = new Vector3(3478, 7872, -50);
        }
    }

    public void WIND_FightScene_Random()
    {
        TravelToFight();
    }

    public void ContiuneFromTutorial()
    {
        CameraTransform.position = new Vector3(3478, 7872, -50);
    }

}
