
public class Pirate : Monster
{

    public Pirate()
    {
        MonsterID = 5;
        Name = "Pirate";
        HitPoints = 120;
        Armor = 14;
        Speed = 9;
        Damage = 9;
        HitAttack = 6;
        ExpGive = 20;
        GoldGive = 16;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 100;
    }
}

