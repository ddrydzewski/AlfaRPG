
public class Monster1 : Monster
{

    public Monster1()
    {
        MonsterID = 1;
        Name = "Goblin";
        HitPoints = 250;
        Armor = 12;
        Speed = 10;
        Damage = 10;
        HitAttack = 6;
        ExpGive = 50;
        GoldGive = 20;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
