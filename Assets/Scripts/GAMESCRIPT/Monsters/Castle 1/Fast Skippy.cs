
public class FastSkippy : Monster
{

    public FastSkippy()
    {
        MonsterID = 2;
        Name = "Fast Skippy";
        HitPoints = 90;
        Armor = 8;
        Speed = 6;
        Damage = 7;
        HitAttack = 5;
        ExpGive = 14;
        GoldGive = 8;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 60;
    }
}
