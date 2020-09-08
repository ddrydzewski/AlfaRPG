
public class Monster10 : Monster
{

    public Monster10()
    {
        MonsterID = 1;
        Name = "Demon";
        HitPoints = 1500;
        Armor = 8;
        Speed = 19;
        Damage = 20;
        HitAttack = 8;
        ExpGive = 800;
        GoldGive = 50;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
