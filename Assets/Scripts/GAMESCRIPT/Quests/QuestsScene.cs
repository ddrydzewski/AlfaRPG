using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsScene : MonoBehaviour
{

    public AllQuests AllQuests;
    public HeroObject Hero;
    public Connector Connector;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// TEXT AND BUTTONS ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public Text NameQuest1Text1, NameQuest1Text2, NameQuest1Text3, NameQuest1Text4, NameQuest1Text5; // CASTLE 1
    public Text NameQuest2Text1, NameQuest2Text2, NameQuest2Text3, NameQuest2Text4, NameQuest2Text5; // CASTLE 2
    public Text NameQuest3Text1, NameQuest3Text2, NameQuest3Text3, NameQuest3Text4, NameQuest3Text5; // CASTLE 3

    public Button ClaimButton1_1, ClaimButton1_2, ClaimButton1_3, ClaimButton1_4, ClaimButton1_5; // CASTLE 1
    public Button ClaimButton2_1, ClaimButton2_2, ClaimButton2_3, ClaimButton2_4, ClaimButton2_5; // CASTLE 2
    public Button ClaimButton3_1, ClaimButton3_2, ClaimButton3_3, ClaimButton3_4, ClaimButton3_5; // CASTLE 3

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// LISTS OF BUTTONS AND LIST OF TEXT /// 
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public List<Text> QuestsTextsListCastle1;
    public List<Text> QuestsTextsListCastle2;
    public List<Text> QuestsTextsListCastle3;

    public List<Button> QuestsButtonsListCastle1;
    public List<Button> QuestsButtonsListCastle2;
    public List<Button> QuestsButtonsListCastle3;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// LISTS OF LISTS ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public List<List<Text>> QuestsTextsLists;
    public List<List<Button>> QuestsButtonsLists;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// THINGS FOR QUESTS ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public int Quest2_2_Battle { get; set; }
    public int Quest2_5_Random { get; set; }
    public bool Quest2_3_6Combo { get; set; }

    void Start()
    {
        AllQuests = new AllQuests();

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// QUESTS TEXTS ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        QuestsTextsListCastle1 = new List<Text>
        {
            NameQuest1Text1, NameQuest1Text2, NameQuest1Text3, NameQuest1Text4, NameQuest1Text5,
        };

        QuestsTextsListCastle2 = new List<Text>
        {
            NameQuest2Text1, NameQuest2Text2, NameQuest2Text3, NameQuest2Text4, NameQuest2Text5,
        };

        QuestsTextsListCastle3 = new List<Text>
        {
            NameQuest3Text1, NameQuest3Text2, NameQuest3Text3, NameQuest3Text4, NameQuest3Text5,
        };

        QuestsTextsLists = new List<List<Text>>
        {
            QuestsTextsListCastle1,
            QuestsTextsListCastle2,
            QuestsTextsListCastle3
        };

        // Add quests Requiremets on Text

        for (int i = 0; i < QuestsTextsLists.Count; i++)
        {
            for (int j = 0; j < QuestsTextsLists[i].Count; j++)
            {
                if(AllQuests.QuestList[i][j].Save != 2)
                QuestsTextsLists[i][j].GetComponent<Text>().text = AllQuests.QuestList[i][j].QuestRequirements;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// QUESTS CLAIM BUTTONS ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        QuestsButtonsListCastle1 = new List<Button>
        {
            ClaimButton1_1, ClaimButton1_2, ClaimButton1_3, ClaimButton1_4, ClaimButton1_5,
        };

        QuestsButtonsListCastle2 = new List<Button>
        {
            ClaimButton2_1, ClaimButton2_2, ClaimButton2_3, ClaimButton2_4, ClaimButton2_5,
        };

        QuestsButtonsListCastle3 = new List<Button>
        {
            ClaimButton3_1, ClaimButton3_2, ClaimButton3_3, ClaimButton3_4, ClaimButton3_5,
        };

        QuestsButtonsLists = new List<List<Button>>
        {
            QuestsButtonsListCastle1,
            QuestsButtonsListCastle2,
            QuestsButtonsListCastle3
        };

        // All buttons first must be SetActive False

        for (int i = 0; i < QuestsButtonsLists.Count; i++)
        {
            for (int j = 0; j < QuestsButtonsLists[i].Count; j++)
            {
                QuestsButtonsLists[i][j].gameObject.SetActive(false);
            }
        }

    }

    void Update()
    {
        // Checks if quest is complete and player dont take reward yet then Claim button set active 

        if (Connector.Quests == true)
        {
            for (int i = 0; i < AllQuests.QuestList.Count; i++)
            {
                for (int j = 0; j < AllQuests.QuestList[i].Count; j++)
                {
                    if (AllQuests.QuestList[i][j].QuestComplete == true && AllQuests.QuestList[i][j].QuestEndReward != true)
                        QuestsButtonsLists[i][j].gameObject.SetActive(true);
                }
            }

            /////////////////////////////////
            /// Quest1_3 ///
            /////////////////////////////////

            if ((Hero.hero.ArmorSet > 1 || Hero.hero.BootsSet > 1 || Hero.hero.GlovesSet > 1 || Hero.hero.WeaponLvl > 1) && AllQuests.QuestList[0][2].QuestComplete != true)
            {
                AllQuests.QuestList[0][2].QuestComplete = true;
                AllQuests.QuestList[0][2].Save = 1;
            }

            /////////////////////////////////
            /// Quest1_4 ///
            /////////////////////////////////
            
            if (Hero.hero.HeroLevel == 5 && AllQuests.QuestList[0][3].QuestComplete != true)
            {
                AllQuests.QuestList[0][3].QuestComplete = true;
                AllQuests.QuestList[0][3].Save = 1;
            }

            /////////////////////////////////
            /// Quest3_3 ///
            /////////////////////////////////

            if (Hero.hero.HeroLevel == 20 && AllQuests.QuestList[2][3].QuestComplete != true && Connector.WhichCastle >= 2)
            {
                AllQuests.QuestList[2][2].QuestComplete = true;
                AllQuests.QuestList[2][2].Save = 1;
            }

            /////////////////////////////////
            /// Quest3_2 ///
            /////////////////////////////////

            if (Hero.hero.ArmorSet == 7 || Hero.hero.BootsSet == 7 || Hero.hero.GlovesSet == 7 || Hero.hero.WeaponLvl == 7 && AllQuests.QuestList[2][2].QuestComplete != true && Connector.WhichCastle >= 2)
            {
                AllQuests.QuestList[2][1].QuestComplete = true;
                AllQuests.QuestList[2][1].Save = 1;
            }

            /////////////////////////////////
            /// Quest3_4 ///
            /////////////////////////////////

            if ((Hero.hero.ArmorSet > 5 && Hero.hero.BootsSet > 5 && Hero.hero.GlovesSet > 5 && Hero.hero.WeaponLvl > 5) && AllQuests.QuestList[2][3].QuestComplete != true)
            {
                AllQuests.QuestList[2][3].QuestComplete = true;
                AllQuests.QuestList[2][3].Save = 1;
            }

        }

        if (Hero.hero.Experience > Hero.hero.ExpList[Hero.hero.HeroLevel - 1])
        {
            Hero.hero.HeroLevel++;
            Hero.hero.LevelPoints += 5;
        }

    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    // CASTLE I
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ClaimButton1_1XD()
    {
        if (AllQuests.QuestList[0][0].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[0][0].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[0][0].QuestExpGive;
            ClaimButton1_1.gameObject.SetActive(false);
            AllQuests.QuestList[0][0].QuestEndReward = true;
            AllQuests.QuestList[0][0].Save = 2;
            NameQuest1Text1.enabled = false;
        }
    }
    public void ClaimButton1_2XD()
    {
        if (AllQuests.QuestList[0][1].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[0][1].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[0][1].QuestExpGive;
            ClaimButton1_2.gameObject.SetActive(false);
            AllQuests.QuestList[0][1].QuestEndReward = true;
            AllQuests.QuestList[0][1].Save = 2;
            NameQuest1Text2.enabled = false;
        }
    }
    public void ClaimButton1_3XD()
    {
        if (AllQuests.QuestList[0][2].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[0][2].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[0][2].QuestExpGive;
            ClaimButton1_3.gameObject.SetActive(false);
            AllQuests.QuestList[0][2].QuestEndReward = true;
            AllQuests.QuestList[0][2].Save = 2;
            NameQuest1Text3.enabled = false;
        }
    }
    public void ClaimButton1_4XD()
    {
        if (AllQuests.QuestList[0][3].QuestComplete == true)
        {

            Hero.hero.Gold += AllQuests.QuestList[0][3].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[0][3].QuestExpGive;
            ClaimButton1_4.gameObject.SetActive(false);
            AllQuests.QuestList[0][3].QuestEndReward = true;
            AllQuests.QuestList[0][3].Save = 2;
            NameQuest1Text4.enabled = false;
        }
    }
    public void ClaimButton1_5XD()
    {
        if (AllQuests.QuestList[0][4].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[0][4].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[0][4].QuestExpGive;
            ClaimButton1_5.gameObject.SetActive(false);
            AllQuests.QuestList[0][4].QuestEndReward = true;
            AllQuests.QuestList[0][4].Save = 2;
            NameQuest1Text5.enabled = false;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    // CASTLE II
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ClaimButton2_1XD()
    {

        if (AllQuests.QuestList[1][0].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[1][0].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[1][0].QuestExpGive;
            ClaimButton2_1.gameObject.SetActive(false);
            AllQuests.QuestList[1][0].QuestEndReward = true;
            AllQuests.QuestList[1][0].Save = 2;
            NameQuest2Text1.enabled = false;
        }
    }
    public void ClaimButton2_2XD()
    {
        if (AllQuests.QuestList[1][1].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[1][1].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[1][1].QuestExpGive;
            ClaimButton2_2.gameObject.SetActive(false);
            AllQuests.QuestList[1][1].QuestEndReward = true;
            AllQuests.QuestList[1][1].Save = 2;
            NameQuest2Text2.enabled = false;
        }
    }
    public void ClaimButton2_3XD()
    {
        if (AllQuests.QuestList[1][2].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[1][2].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[1][2].QuestExpGive;
            ClaimButton2_3.gameObject.SetActive(false);
            AllQuests.QuestList[1][2].QuestEndReward = true;
            AllQuests.QuestList[1][2].Save = 2;
            NameQuest2Text3.enabled = false;
        }
    }
    public void ClaimButton2_4XD()
    {
        if (AllQuests.QuestList[1][3].QuestComplete == true)
        {

            Hero.hero.Gold += AllQuests.QuestList[1][3].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[1][3].QuestExpGive;
            ClaimButton2_4.gameObject.SetActive(false);
            AllQuests.QuestList[1][3].QuestEndReward = true;
            AllQuests.QuestList[1][3].Save = 2;
            NameQuest2Text4.enabled = false;
        }
    }
    public void ClaimButton2_5XD()
    {
        if (AllQuests.QuestList[1][4].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[1][4].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[1][4].QuestExpGive;
            ClaimButton2_5.gameObject.SetActive(false);
            AllQuests.QuestList[1][4].QuestEndReward = true;
            AllQuests.QuestList[1][4].Save = 2;
            NameQuest2Text5.enabled = false;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    // CASTLE III
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ClaimButton3_1XD()
    {

        if (AllQuests.QuestList[2][0].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[2][0].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[2][0].QuestExpGive;
            ClaimButton3_1.gameObject.SetActive(false);
            AllQuests.QuestList[2][0].QuestEndReward = true;
            AllQuests.QuestList[2][0].Save = 2;
            NameQuest3Text1.enabled = false;
        }
    }
    public void ClaimButton3_2XD()
    {
        if (AllQuests.QuestList[2][1].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[2][1].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[2][1].QuestExpGive;
            ClaimButton3_2.gameObject.SetActive(false);
            AllQuests.QuestList[2][1].QuestEndReward = true;
            AllQuests.QuestList[2][1].Save = 2;
            NameQuest3Text2.enabled = false;
        }
    }
    public void ClaimButton3_3XD()
    {
        if (AllQuests.QuestList[2][2].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[2][2].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[2][2].QuestExpGive;
            ClaimButton3_3.gameObject.SetActive(false);
            AllQuests.QuestList[2][2].QuestEndReward = true;
            AllQuests.QuestList[2][2].Save = 2;
            NameQuest3Text3.enabled = false;
        }
    }
    public void ClaimButton3_4XD()
    {
        if (AllQuests.QuestList[2][3].QuestComplete == true)
        {

            Hero.hero.Gold += AllQuests.QuestList[2][3].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[2][3].QuestExpGive;
            ClaimButton3_4.gameObject.SetActive(false);
            AllQuests.QuestList[2][3].QuestEndReward = true;
            AllQuests.QuestList[2][3].Save = 2;
            NameQuest3Text4.enabled = false;
        }
    }
    public void ClaimButton3_5XD()
    {
        if (AllQuests.QuestList[2][4].QuestComplete == true)
        {
            Hero.hero.Gold += AllQuests.QuestList[2][4].QuestGoldGive;
            Hero.hero.Experience += AllQuests.QuestList[2][4].QuestExpGive;
            ClaimButton3_5.gameObject.SetActive(false);
            AllQuests.QuestList[2][4].QuestEndReward = true;
            AllQuests.QuestList[2][4].Save = 2;
            NameQuest3Text5.enabled = false;
        }
    }

}
