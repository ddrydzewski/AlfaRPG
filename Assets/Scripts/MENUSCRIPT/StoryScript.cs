using UnityEngine;
using UnityEngine.UI;

public class StoryScript : MonoBehaviour
{

    private Vector3 Positions;
    public float Speed = 2.0f;
    public int Scene = 1;
    public bool CanIClickNext = false;
    public Button NextButton, ContinueButton;

    public void ButtonGo()
    {
        if (CanIClickNext == true)
        {
            Scene++;
            CanIClickNext = false;
        }
    }

}
