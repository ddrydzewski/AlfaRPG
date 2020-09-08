

public class Monster8 : Monster
{

    public Monster8()
    {
        MonsterID = 1;
        Name = "Hydra";
        HitPoints = 1300;
        Armor = 8;
        Speed = 17;
        Damage = 16;
        HitAttack = 7;
        ExpGive = 500;
        GoldGive = 34;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
