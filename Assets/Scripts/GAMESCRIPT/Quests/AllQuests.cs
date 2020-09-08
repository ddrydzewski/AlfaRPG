using System.Collections.Generic;

public class AllQuests
{
    // Quests FLOOR I

    private Quest1_1 Quest1_1;
    private Quest2_1 Quest2_1;
    private Quest3_1 Quest3_1;
    private Quest4_1 Quest4_1;
    private Quest5_1 Quest5_1;

    // Quests FLOOR II

    private Quest1_2 Quest1_2;
    private Quest2_2 Quest2_2;
    private Quest3_2 Quest3_2;
    private Quest4_2 Quest4_2;
    private Quest5_2 Quest5_2;

    // Quests FLOOR III

    private Quest1_3 Quest1_3;
    private Quest2_3 Quest2_3;
    private Quest3_3 Quest3_3;
    private Quest4_3 Quest4_3;
    private Quest5_3 Quest5_3;

    // Quests List Floor/Castle

    public List<Quest> QuestsListCastle_1;
    public List<Quest> QuestsListCastle_2;
    public List<Quest> QuestsListCastle_3;

    // List of List Quests

    public List<List<Quest>> QuestList;

    public AllQuests()
    {
        Quest1_1 = new Quest1_1();
        Quest2_1 = new Quest2_1();
        Quest3_1 = new Quest3_1();
        Quest4_1 = new Quest4_1();
        Quest5_1 = new Quest5_1();

        Quest1_2 = new Quest1_2();
        Quest2_2 = new Quest2_2();
        Quest3_2 = new Quest3_2();
        Quest4_2 = new Quest4_2();
        Quest5_2 = new Quest5_2();

        Quest1_3 = new Quest1_3();
        Quest2_3 = new Quest2_3();
        Quest3_3 = new Quest3_3();
        Quest4_3 = new Quest4_3();
        Quest5_3 = new Quest5_3();
        
        QuestsListCastle_1 = new List<Quest>
        {
            Quest1_1, Quest2_1, Quest3_1, Quest4_1, Quest5_1
        };

        QuestsListCastle_2 = new List<Quest>
        {
            Quest1_2, Quest2_2, Quest3_2, Quest4_2, Quest5_2
        };

        QuestsListCastle_3 = new List<Quest>
        {
            Quest1_3, Quest2_3, Quest3_3, Quest4_3, Quest5_3
        };

        QuestList = new List<List<Quest>>
        {
            QuestsListCastle_1,
            QuestsListCastle_2,
            QuestsListCastle_3
        };

    }

}
