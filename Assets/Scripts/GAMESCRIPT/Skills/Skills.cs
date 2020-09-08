using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{

    public HeroObject hero;
    public Connector Connector;
    public QuestsScene QuestsScene;

    public Text LvlText, HpText, ArmorText, SpdText, DamageText, StrText, ViText, DexText, ExpText;
    public Text PointsLeft;

    public Image StrImage, VitImage, DexImage;
    public Image IsLvlImage;

    void Start()
    {
        StrImage.enabled = false;
        VitImage.enabled = false;
        DexImage.enabled = false;
    }

    void Update()
    {
        if (hero.hero.LevelPoints > 0)
            IsLvlImage.enabled = true;
        if (hero.hero.LevelPoints <= 0)
            IsLvlImage.enabled = false;

        if (Connector.Skills == true)
        {
            LvlText.GetComponent<Text>().text = hero.hero.HeroLevel.ToString();
            HpText.GetComponent<Text>().text = hero.hero.HitPoints.ToString();
            ArmorText.GetComponent<Text>().text = hero.hero.Armor.ToString();
            SpdText.GetComponent<Text>().text = hero.hero.Speed.ToString();
            DamageText.GetComponent<Text>().text = hero.hero.Damage.ToString();
            StrText.GetComponent<Text>().text = hero.hero.Strength.ToString();
            ViText.GetComponent<Text>().text = hero.hero.Vitality.ToString();
            DexText.GetComponent<Text>().text = hero.hero.Dexterity.ToString();
            ExpText.GetComponent<Text>().text = "Exp: " + hero.hero.Experience.ToString() + "/" +
                                                hero.hero.ExpList[hero.hero.HeroLevel - 1].ToString();

            hero.hero.DefaultHero();

            if (hero.hero.LevelPoints > 0)
            {
                StrImage.enabled = true;
                VitImage.enabled = true;
                DexImage.enabled = true;
                PointsLeft.GetComponent<Text>().text = "Points left: " + hero.hero.LevelPoints.ToString();
            }

            if (hero.hero.LevelPoints <= 0)
            {
                StrImage.enabled = false;
                VitImage.enabled = false;
                DexImage.enabled = false;
                PointsLeft.enabled = false;
            }        
        }

        if (Connector.ForgeUp == true)
        {
            hero.hero.DefaultHero();
        }
    }

    public void StrUp()
    {
        if (hero.hero.LevelPoints > 0)
        {
            hero.hero.Strength++;
            hero.hero.LevelPoints--;
        }
    }

    public void DexUp()
    {
        if (hero.hero.LevelPoints > 0)
        {
            hero.hero.Dexterity++;
            hero.hero.LevelPoints--;
        }
    }

    public void VitUp()
    {
        if (hero.hero.LevelPoints > 0)
        {
            hero.hero.Vitality++;
            hero.hero.LevelPoints--;
        }
    }
}
