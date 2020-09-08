

public class Thief : Monster
{

    public Thief()
    {
        MonsterID = 4;
        Name = "Thief";
        HitPoints = 110;
        Armor = 12;
        Speed = 8;
        Damage = 8;
        HitAttack = 5;
        ExpGive = 16;
        GoldGive = 14;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 80;
    }
}
