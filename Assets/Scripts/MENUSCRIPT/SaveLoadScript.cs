using UnityEngine;

public class SaveLoadScript : MonoBehaviour
{

    public HeroObject Hero;
    public MonsterObject Monster;
    public QuestsScene Quests;

    public void Save()
    {

        // Hero Saves
        PlayerPrefs.SetInt("HeroExp", Hero.hero.Experience);
        PlayerPrefs.SetInt("HeroLvl", Hero.hero.HeroLevel);
        PlayerPrefs.SetInt("HeroGold", Hero.hero.Gold);
        PlayerPrefs.SetInt("HeroLvlPoints", Hero.hero.LevelPoints);
        PlayerPrefs.SetInt("HeroStr", Hero.hero.Strength);
        PlayerPrefs.SetInt("HeroVit", Hero.hero.Vitality);
        PlayerPrefs.SetInt("HeroDex", Hero.hero.Dexterity);
        PlayerPrefs.SetInt("HeroArm", Hero.hero.ArmorSet);
        PlayerPrefs.SetInt("HeroTSS", Hero.hero.TransformSS);
        PlayerPrefs.SetInt("HeroWepLvl", Hero.hero.WeaponLvl);
        PlayerPrefs.SetInt("HeroBootsLvl", Hero.hero.BootsSet);
        PlayerPrefs.SetInt("HeroGlovesLvl", Hero.hero.GlovesSet);
        PlayerPrefs.SetInt("HeroNewGame",Hero.hero.NewGame);

        // Program try saves data but when we dont fight on first time when we play game then all this data is null

        try
        {
            // Monsters Beats Saves
            for (int i = 0; i < Monster.allMonsters.MonsterList.Count; i++)
            {
                for (int j = 0; j < Monster.allMonsters.MonsterList[i].Count; j++)
                {
                    PlayerPrefs.SetInt("MonsterBeat" + i + j, Monster.allMonsters.MonsterList[i][j].BeatCounter);
                }
            }

            // Quests Complete Saves
            for (int i = 0; i < Quests.AllQuests.QuestList.Count; i++)
            {
                for (int j = 0; j < Quests.AllQuests.QuestList[i].Count; j++)
                {
                    PlayerPrefs.SetInt("QuestComplete" + i + j, Quests.AllQuests.QuestList[i][j].Save);
                }
            }
        }
        catch { }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("HeroDex") != 0)
        {
            Hero.hero.Dexterity = PlayerPrefs.GetInt("HeroDex");
            Hero.hero.Strength = PlayerPrefs.GetInt("HeroStr");
            Hero.hero.Vitality = PlayerPrefs.GetInt("HeroVit");
            Hero.hero.HeroLevel = PlayerPrefs.GetInt("HeroLvl");
            Hero.hero.Experience = PlayerPrefs.GetInt("HeroExp");
            Hero.hero.Gold = PlayerPrefs.GetInt("HeroGold");
            Hero.hero.WeaponLvl = PlayerPrefs.GetInt("HeroWepLvl");
            Hero.hero.LevelPoints = PlayerPrefs.GetInt("HeroLvlPoints");
            Hero.hero.TransformSS = PlayerPrefs.GetInt("HeroTSS");
            Hero.hero.ArmorSet = PlayerPrefs.GetInt("HeroArm");
            Hero.hero.BootsSet = PlayerPrefs.GetInt("HeroBootsLvl");
            Hero.hero.GlovesSet = PlayerPrefs.GetInt("HeroGlovesLvl");
            Hero.hero.NewGame = PlayerPrefs.GetInt("HeroNewGame");

            try
            {
                for (int i = 0; i < Monster.allMonsters.MonsterList.Count; i++)
                {
                    for (int j = 0; j < Monster.allMonsters.MonsterList[i].Count; j++)
                    {
                        Monster.allMonsters.MonsterList[i][j].BeatCounter = PlayerPrefs.GetInt("MonsterBeat" + i + j);
                    }
                }

            }
            catch { }

            try
            {
                for (int i = 0; i < Quests.AllQuests.QuestList.Count; i++)
                {
                    for (int j = 0; j < Quests.AllQuests.QuestList[i].Count; j++)
                    {
                        Quests.AllQuests.QuestList[i][j].Save = PlayerPrefs.GetInt("QuestComplete" + i + j);
                    }
                }


                for (int i = 0; i < Quests.AllQuests.QuestList.Count; i++)
                {
                    for (int j = 0; j < Quests.AllQuests.QuestList[i].Count; j++)
                    {
                        if (Quests.AllQuests.QuestList[i][j].Save == 0)
                        {
                            Quests.AllQuests.QuestList[i][j].QuestComplete = false;
                            Quests.AllQuests.QuestList[i][j].QuestEndReward = false;
                        }
                        else if (Quests.AllQuests.QuestList[i][j].Save == 1)
                        {
                            Quests.AllQuests.QuestList[i][j].QuestComplete = true;
                            Quests.AllQuests.QuestList[i][j].QuestEndReward = false;
                        }
                        else if (Quests.AllQuests.QuestList[i][j].Save == 2)
                        {
                            Quests.AllQuests.QuestList[i][j].QuestComplete = true;
                            Quests.AllQuests.QuestList[i][j].QuestEndReward = true;
                        }
                    }
                }

            }
            catch { }

        }
    }

}
