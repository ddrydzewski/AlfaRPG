

public class Monster3 : Monster
{

    public Monster3()
    {
        MonsterID = 1;
        Name = "Skeleton";
        HitPoints = 300;
        Armor = 8;
        Speed = 12;
        Damage = 12;
        HitAttack = 6;
        ExpGive = 60;
        GoldGive = 23;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
