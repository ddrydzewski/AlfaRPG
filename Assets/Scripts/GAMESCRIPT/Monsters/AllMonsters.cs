using System.Collections.Generic;

public class AllMonsters
{
    // CASTLE 1

    public Bandit Bandit;
    public GreenGlue GreenGlue;
    public Thief Thief;
    public Pirate Pirate;
    public FastSkippy FastSkippy;

    // CASTLE 2

    public Monster1 Monster1;
    public Monster2 Monster2;
    public Monster3 Monster3;
    public Monster4 Monster4;
    public Monster5 Monster5;

    // CASTLE 3

    public Monster6 Monster6;
    public Monster7 Monster7;
    public Monster8 Monster8;
    public Monster9 Monster9;
    public Monster10 Monster10;

    // BOSSES

    public Boss1 Boss1;
    public Boss2 Boss2;
    public Boss3 Boss3;

    // LIST OF MONSTERS !!

    public List<Monster> Monsters_Castle1;
    public List<Monster> Monsters_Castle2;
    public List<Monster> Monsters_Castle3;

    // List of monsters list

    public List<List<Monster>> MonsterList;

    // If true Player do at least 1 battle 
    public bool BattleSave { get; set; }

    public AllMonsters()
    {
        // CASTLE 1

        Bandit = new Bandit();
        GreenGlue = new GreenGlue();
        Thief = new Thief();
        Pirate = new Pirate();
        FastSkippy = new FastSkippy();

        // CASTLE 2

        Monster1 = new Monster1();
        Monster2 = new Monster2();
        Monster3 = new Monster3();
        Monster4 = new Monster4();
        Monster5 = new Monster5();

        // CASTLE 3

        Monster6 = new Monster6();
        Monster7 = new Monster7();
        Monster8 = new Monster8();
        Monster9 = new Monster9();
        Monster10 = new Monster10();

        Boss1 = new Boss1();
        Boss2 = new Boss2();
        Boss3 = new Boss3();

        BattleSave = false;

        Monsters_Castle1 = new List<Monster>
        {
            GreenGlue,
            FastSkippy,
            Bandit,
            Thief,
            Pirate,
            Boss1
        };

        Monsters_Castle2 = new List<Monster>
        {
            Monster1,
            Monster2,
            Monster3,
            Monster4,
            Monster5,
            Boss2
        };

        Monsters_Castle3 = new List<Monster>
        {
            Monster6,
            Monster7,
            Monster8,
            Monster9,
            Monster10,
            Boss3
        };

        MonsterList = new List<List<Monster>>
        {
            Monsters_Castle1,
            Monsters_Castle2,
            Monsters_Castle3
        };
    }

    public void DefaultMonsters()
    {
        Bandit.Default();
        GreenGlue.Default();
        Pirate.Default();
        FastSkippy.Default();
        Thief.Default();

        Monster1.Default();
        Monster2.Default();
        Monster3.Default();
        Monster4.Default();
        Monster5.Default();

        Monster6.Default();
        Monster7.Default();
        Monster8.Default();
        Monster9.Default();
        Monster10.Default();
    }
}
