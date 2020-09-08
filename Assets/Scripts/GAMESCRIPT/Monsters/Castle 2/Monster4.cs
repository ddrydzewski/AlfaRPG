
public class Monster4 : Monster
{

    public Monster4()
    {
        MonsterID = 1;
        Name = "Ghost";
        HitPoints = 350;
        Armor = 8;
        Speed = 13;
        Damage = 13;
        HitAttack = 6;
        ExpGive = 70;
        GoldGive = 25;

        BeatCounter = 0;
    }

    public void Default()
    {
        HitPoints = 150;
    }
}
