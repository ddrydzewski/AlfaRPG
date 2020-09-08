
public class Bandit : Monster
{

    public Bandit()
    {
        MonsterID = 1;
        Name = "Bandit";
        HitPoints = 100;
        Armor = 10;
        Speed = 7;
        Damage = 8;
        HitAttack = 5;
        ExpGive = 15;
        GoldGive = 10;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
