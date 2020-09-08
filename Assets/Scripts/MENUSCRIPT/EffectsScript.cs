using UnityEngine;
using UnityEngine.UI;

public class EffectsScript : MonoBehaviour
{
    public Text ContinueText;

    void Update()
    {
        if (PlayerPrefs.GetInt("HeroDex") == 0)
        {
            ContinueText.color = new Color(0.3f, 0.3f, 0.3f, 1);
        }
    }
}
