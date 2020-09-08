using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForgeUp : MonoBehaviour
{
    public HeroObject Hero;
    public Text GoldText;

    public Text ArmorSetText;
    public Text WeaponSetText;
    public Text BootsSetText;
    public Text GlovesSetText;

    public Text ArmorCostText;
    public Text WeaponCostText;
    public Text BootsCostTest;
    public Text GlovesCostTest;

    private int FirstLvlUp, SecondLvlUp, ThirdLvlUp, FourthLvlUp, FifthLvlUp, SixthLvlUp, SeventhLvlUp;

    private List<int> ListOfCost;

    void Start()
    {
        FirstLvlUp = 75;
        SecondLvlUp = 170;
        ThirdLvlUp = 350;
        FourthLvlUp = 600;
        FifthLvlUp = 1200;
        SixthLvlUp = 2500;
        SeventhLvlUp = 6000;


        ListOfCost = new List<int>()
        {
            FirstLvlUp,
            SecondLvlUp,
            ThirdLvlUp,
            FourthLvlUp,
            FifthLvlUp,
            SixthLvlUp,
            SeventhLvlUp
        };
    }

    void Update()
    {
        GoldText.GetComponent<Text>().text = "Gold: " + Hero.hero.Gold.ToString();
        ArmorSetText.GetComponent<Text>().text = "Armor Set: " + (Hero.hero.ArmorSet + 1).ToString();
        WeaponSetText.GetComponent<Text>().text = "Weapon Set: " + (Hero.hero.WeaponLvl + 1).ToString();
        BootsSetText.GetComponent<Text>().text = "Boots Set: " + (Hero.hero.BootsSet + 1).ToString();
        GlovesSetText.GetComponent<Text>().text = "Gloves Set: " + (Hero.hero.GlovesSet + 1).ToString();
        ArmorCostText.GetComponent<Text>().text = "Cost: " + ListOfCost[Hero.hero.ArmorSet].ToString();
        WeaponCostText.GetComponent<Text>().text = "Cost: " + ListOfCost[Hero.hero.WeaponLvl].ToString();
        BootsCostTest.GetComponent<Text>().text = "Cost: " + ListOfCost[Hero.hero.BootsSet].ToString();
        GlovesCostTest.GetComponent<Text>().text = "Cost: " + ListOfCost[Hero.hero.GlovesSet].ToString();
    }

    public void UpgradeArmor()
    {
        if (Hero.hero.Gold > ListOfCost[Hero.hero.ArmorSet] && Hero.hero.ArmorSet < ListOfCost.Count - 1)
        {
            Hero.hero.Gold -= ListOfCost[Hero.hero.ArmorSet];
            Hero.hero.ArmorSet++;
        }
    }

    public void UpgradeWeapon()
    {
        if (Hero.hero.Gold > ListOfCost[Hero.hero.WeaponLvl] && Hero.hero.WeaponLvl < ListOfCost.Count - 1)
        {
            Hero.hero.Gold -= ListOfCost[Hero.hero.WeaponLvl];
            Hero.hero.WeaponLvl++;
        }
    }

    public void UpgradeBoots()
    {
        if (Hero.hero.Gold > ListOfCost[Hero.hero.BootsSet] && Hero.hero.BootsSet < ListOfCost.Count - 1)
        {
            Hero.hero.Gold -= ListOfCost[Hero.hero.BootsSet];
            Hero.hero.BootsSet++;
        }
    }

    public void UpgradeGloves()
    {
        if (Hero.hero.Gold > ListOfCost[Hero.hero.GlovesSet] && Hero.hero.GlovesSet < ListOfCost.Count - 1)
        {
            Hero.hero.Gold -= ListOfCost[Hero.hero.GlovesSet];
            Hero.hero.GlovesSet++;
        }
    }

}
