using UnityEngine;

public class HeroObject : MonoBehaviour
{
    public Hero hero;

    void Start()
    {
        hero = new Hero();
    }
}
