using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{

    public bool Castle_1 { get; set; }
    public bool Castle_2 { get; set; }
    public bool Castle_3 { get; set; }

    public bool GoBoss { get; set; }

    public int WhichCastle { get; set; }

    public bool Skills { get; set; }
    public bool ForgeUp { get; set; }
    public bool BigMountain { get; set; }
    public bool Quests { get; set; }

    public bool RandomFight { get; set; }
    public bool GoGoFight { get; set; }
    public int ChoseMonster { get; set; }

    public int QuestScene { get; set; }

    public Vector3 Quests1 { get; set; }
    public Vector3 Quests2 { get; set; }
    public Vector3 Quests3 { get; set; }
    public Vector3 QuestsMain { get; set; }

    void Start()
    {
        Castle_1 = false;
        Castle_2 = false;
        Castle_3 = false;

        GoBoss = false;

        Skills = false;
        ForgeUp = false;
        BigMountain = false;
        Quests = false;
        RandomFight = false;
        GoGoFight = false;

        WhichCastle = 0;

        QuestsMain = new Vector3(-5493, -71, -50);
        Quests1 = new Vector3(-7663, -89, -50);
        Quests2 = new Vector3(-3359, -69, -50);
        Quests3 = new Vector3(-5480, -3134, -50);

    }
}
