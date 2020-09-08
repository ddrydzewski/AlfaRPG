public class Quest
{

    public int QuestExpGive { get; set; }
    public int QuestGoldGive { get; set; }

    public bool QuestComplete { get; set; }
    public bool QuestEndReward { get; set; }

    public string QuestName { get; set; }
    public string QuestRequirements { get; set; }

    // 1 Quest complete, 0 isn't
    public int Save { get; set; }
}


