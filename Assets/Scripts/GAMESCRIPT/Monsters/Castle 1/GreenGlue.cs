
public class GreenGlue : Monster
{

    public GreenGlue()
    {
        MonsterID = 3;
        Name = "Green Glue";
        HitPoints = 80;
        Armor = 6;
        Speed = 5;
        Damage = 7;
        HitAttack = 5;
        ExpGive = 13;
        GoldGive = 6;

        BeatCounter = 0;

    }
    public void Default()
    {
        HitPoints = 100;
    }
}
