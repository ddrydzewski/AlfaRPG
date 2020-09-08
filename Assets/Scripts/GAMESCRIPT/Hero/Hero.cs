using System.Collections.Generic;
using UnityEngine;

public class Hero
{

    public int HitPoints { get; set; }
    public int Armor { get; set; }
    public int Speed { get; set; }

    // ATTRIBUTES
    public int Strength { get; set; }
    public int Vitality { get; set; }
    public int Dexterity { get; set; }

    public int Experience { get; set; }
    public int HeroLevel { get; set; }
    public int TransformSS { get; set; }
    public int Gold { get; set; }

    // ITEMS SET
    public int ArmorSet { get; set; }
    public int WeaponLvl { get; set; }
    public int BootsSet { get; set; }
    public int GlovesSet { get; set; }

    public int Damage { get; set; }
    public int DamageDealt { get; set; }
    public int LevelPoints { get; set; }

    public int NewGame { get; set; }

    public List<int> ExpList;

    public Hero()
    {

        Strength = 10;
        Vitality = 10;
        Dexterity = 10;

        Experience = 0;
        HeroLevel = 1;
        TransformSS = 1;
        LevelPoints = 0;
        Gold = 15;

        ArmorSet = 0;
        WeaponLvl = 0;
        BootsSet = 0;
        GlovesSet = 0;    

        DefaultHero();

        DamageDealt = 0;
        NewGame = 0;

        ExpList = new List<int>()
        {
            50,
            125,  
            225,
            350,
            600,
            900,
            1200,
            1550,
            1900,
            2500,
            3000,
            3750,
            4500,
            6000,
            8000,
            11000,
            15000,
            20000,
            25000,
            35000,
            50000,
            75000,
            100000,
            150000
        };

        // 24 LVLE
    }

    // MAIN CHANGE HERO

    public void DefaultHero()
    {
        HitPoints = Vitality * 10;
        Armor = Dexterity / 2 + (ArmorSet + 1) * 2;
        Damage = Strength / 2 + (WeaponLvl + 1) * 2;
        Speed = 2 + Dexterity / 2 + (BootsSet + 1 * 2);
    }

}
