

public class Monster6 : Monster
{

    public Monster6()
    {
        MonsterID = 1;
        Name = "Troll";
        HitPoints = 1000;
        Armor = 8;
        Speed = 15;
        Damage = 15;
        HitAttack = 7;
        ExpGive = 250;
        GoldGive = 30;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
