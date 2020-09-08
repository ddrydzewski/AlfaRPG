using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class PrepareFight : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// All preparation class before fight 
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Random number which affect to random shape
    public int RandomButton { get; set; }
    public int RandomButtonChange { get; set; }
    public int RandomMonster { get; set; }
    public int RandomColor { get; set; }

    public int GoldGive { get; set; }
    public int ExpGive { get; set; }

    // Player chose shape and this is his number - For example player take Circle and this is 0
    public int NumberOfButton { get; set; }

    // Combo Points 
    public int ComboPoints { get; set; }
    public int ComboPointsChange { get; set; }
    public int HowMuchHitMe { get; set; }
    public int MonsterDamageDealt { get; set; }

    // Round 
    public int RoundNumber { get; set; }
    public int MonsterRoundNumber { get; set; }

    // Waiting time
    public float Timer { get; set; }
    public float WaitingForPlayer { get; set; }

    // CanITap is for security, Olny One time player can touch shape and can't change it 
    public bool CanITap;

    // Only one is for one combo touch and All when Combo stops 
    public bool EndOfCombo_Only_one { get; set; }
    public bool EndOfCombo_All { get; set; }
    public bool IsFighting { get; set; }
    public bool ClickEnd { get; set; }

    // Whose turn is / True Player / False Monster
    public bool HeroTurn { get; set; }
    public bool ChangeTurn { get; set; }

    // Objects 
    public HeroObject MyHero;
    public MonsterObject MyMonsters;
    public NextScene Next;
    public QuestsScene Quests;
    public ImageTextsToFight ImageTextsToFight;
    public SaveLoadScript SaveLoad;

    // Button which start battle 
    public Button StartButton;
    public Button ContinueButton;

    // Position for change touch signs
    // public Vector3 Pos1, Pos2, Pos3, Pos4;

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Use this for initialization
    void Start()
    {
        // When game begins Player can tap on shape
        CanITap = true;

        // 0 means that Player did't touch shape yet
        NumberOfButton = 0;
        RoundNumber = 0;

        EndOfCombo_Only_one = true;
        EndOfCombo_All = false;
        ComboPoints = 0;
        ComboPointsChange = 0;
        RandomMonster = 0;
        RandomButtonChange = 0;
        MonsterRoundNumber = 1;
        GoldGive = 0;
        HowMuchHitMe = 0;
        Quests.Quest2_2_Battle = 0;
        MonsterDamageDealt = 0;

        // Times -> 1.9 Seconds
        WaitingForPlayer = 1.9f;
        Timer = WaitingForPlayer;
        ChangeTurn = true;
        ClickEnd = false;
        ContinueButton.enabled = false;
        ContinueButton.gameObject.SetActive(false);

        /*
        Pos1 = new Vector3(-409, -848, 0);
        Pos2 = new Vector3(-27, -648, 0);
        Pos3 = new Vector3(-27, -1045, 0);
        Pos4 = new Vector3(353, -848, 0);
        */
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Prepare fight
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void PreFight()
    {
        IsFighting = true;
        MyMonsters.allMonsters.BattleSave = true;
        ImageTextsToFight.OnTouchImages();
        ImageTextsToFight.OnStartFight();

        StartButton.enabled = false;
        StartButton.gameObject.SetActive(false);

        if (MyHero.hero.Speed > MyMonsters.allMonsters.MonsterList[Next.Connector.WhichCastle][RandomMonster].Speed)
            HeroTurn = true;
        else
            HeroTurn = false;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Random Monster
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void LosulosuMonster()
    {
        RandomMonster = Random.Range(0, MyMonsters.allMonsters.MonsterList[Next.Connector.ChoseMonster].Count);
        if (Next.Connector.WhichCastle >= 1)
        {
            Quests.Quest2_5_Random++;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Go to Mountain -> After Monster /// Go to Village -> After Boss ///
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void GoToMountain()
    {
        if (IsFighting == false)
        {
            if (Next.Connector.Castle_1 == true)
            {
                Next.BigMountain_Castle1();
            }

            if (Next.Connector.Castle_2 == true)
            {
                Next.BigMountain_Castle2();
            }

            if (Next.Connector.Castle_3 == true)
            {
                Next.BigMountain_Castle3();
            }
        }
    }

    public void GoToVillage()
    {
        Next.Connector.GoBoss = false;
        Next.Village_BigMountain();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Reset all thing for next fight
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void ResetFight()
    {
        // Images And Text enabled on false because we dont want see them 
        SaveLoad.Save();
        MyMonsters.allMonsters.DefaultMonsters();
        MyHero.hero.DefaultHero();

        ImageTextsToFight.HeroHpText.GetComponent<Text>().text = MyHero.hero.HitPoints.ToString();
        ImageTextsToFight.MonsterHpText.GetComponent<Text>().text = MyMonsters.allMonsters.MonsterList[Next.Connector.WhichCastle][RandomMonster].HitPoints.ToString();

        ImageTextsToFight.Reset_Text_Images();

        StartButton.enabled = true;
        StartButton.gameObject.SetActive(true);

        // When game begins Player can tap on shape
        CanITap = true;

        // 0 means that Player did't touch shape yet
        NumberOfButton = 0;
        RoundNumber = 0;

        EndOfCombo_Only_one = true;
        EndOfCombo_All = false;
        ComboPoints = 0;
        ComboPointsChange = 0;
        RandomMonster = 0;
        RandomButtonChange = 0;
        MonsterRoundNumber = 1;
        GoldGive = 0;
        HowMuchHitMe = 0;

        // Times -> 2 Seconds
        WaitingForPlayer = 1.9f;
        Timer = WaitingForPlayer;
        ChangeTurn = true;

        Next.Connector.RandomFight = false;
        ClickEnd = false;
        ContinueButton.enabled = false;
        ContinueButton.gameObject.SetActive(false);
        ImageTextsToFight.GoldGiveText.enabled = false;
        ImageTextsToFight.ExpGiveText.enabled = false;
        ImageTextsToFight.LvlUpText.enabled = false;
        ImageTextsToFight.LvlPanel.enabled = false;
        ImageTextsToFight.RandomPanel.enabled = false;
        ImageTextsToFight.MonsterAttackLeftText.enabled = false;
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}
