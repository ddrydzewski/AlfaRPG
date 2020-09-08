using UnityEngine;

public class MonsterObject : MonoBehaviour
{
    public AllMonsters allMonsters;

    void Start()
    {
        allMonsters = new AllMonsters();
    }
}
