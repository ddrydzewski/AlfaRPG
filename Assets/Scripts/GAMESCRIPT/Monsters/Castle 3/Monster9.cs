

public class Monster9 : Monster
{

    public Monster9()
    {
        MonsterID = 1;
        Name = "Dragon";
        HitPoints = 1400;
        Armor = 8;
        Speed = 18;
        Damage = 18;
        HitAttack = 7;
        ExpGive = 600;
        GoldGive = 35;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
