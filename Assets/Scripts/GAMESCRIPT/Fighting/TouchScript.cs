using UnityEngine;

public class TouchScript : MonoBehaviour
{

    public PrepareFight Prepare;

    public void CircleTouch()
    {
        if (Prepare.CanITap == true && Prepare.Timer > 0 && Prepare.EndOfCombo_Only_one == false && Prepare.ChangeTurn == true)
        {
            Prepare.NumberOfButton = 1;
            Prepare.CanITap = false;
        }
    }

    public void TriangeTouch()
    {
        if (Prepare.CanITap == true && Prepare.Timer > 0 && Prepare.EndOfCombo_Only_one == false && Prepare.ChangeTurn == true)
        {
            Prepare.NumberOfButton = 2;
            Prepare.CanITap = false;
        }
    }

    public void SquareTouch()
    {
        if (Prepare.CanITap == true && Prepare.Timer > 0 && Prepare.EndOfCombo_Only_one == false && Prepare.ChangeTurn == true)
        {
            Prepare.NumberOfButton = 3;
            Prepare.CanITap = false;
        }
    }

    public void DeltoidTouch()
    {
        if (Prepare.CanITap == true && Prepare.Timer > 0 && Prepare.EndOfCombo_Only_one == false && Prepare.ChangeTurn == true)
        {
            Prepare.NumberOfButton = 4;
            Prepare.CanITap = false;
        }
    }

    public void Continue()
    {
        Prepare.ClickEnd = true;
    }
}
