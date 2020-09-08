
public class Monster2 : Monster
{

    public Monster2()
    {
        MonsterID = 1;
        Name = "Ghoul";
        HitPoints = 290;
        Armor = 8;
        Speed = 11;
        Damage = 10;
        HitAttack = 6;
        ExpGive = 55;
        GoldGive = 22;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
