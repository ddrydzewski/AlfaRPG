
public class Monster7 : Monster
{

    public Monster7()
    {
        MonsterID = 1;
        Name = "Giant Spider";
        HitPoints = 1200;
        Armor = 8;
        Speed = 16;
        Damage = 16;
        HitAttack = 7;
        ExpGive = 350;
        GoldGive = 32;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
