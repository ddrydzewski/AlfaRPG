
public class Monster5 : Monster
{

    public Monster5()
    {
        MonsterID = 1;
        Name = "Gigant";
        HitPoints = 400;
        Armor = 8;
        Speed = 14;
        Damage = 15;
        HitAttack = 7;
        ExpGive = 75;
        GoldGive = 29;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
