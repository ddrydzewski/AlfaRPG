using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTextsToFight : MonoBehaviour
{
    // RANDOM IMAGE

    public Image DeltoidBlueImage, DeltoidGreenImage, DeltoidYellowImage, DeltoidBrownImage;
    public Image CircleBlueImage, CircleGreenImage, CircleYellowImage, CircleBrownImage;
    public Image SquareBlueImage, SquareGreenImage, SquareYellowImage, SquareBrownImage;
    public Image TriangleBlueImage, TriangleGreenImage, TriangleYellowImage, TriangleBrownImage;

    // IMAGES WHICH WE TOUCH
    public Image DeltoidTouch, CircleTouch, SquareTouch, TriangleTouch;

    // Panels
    public Image HpUpPanel,
        HpPanel,
        HpBetweenPanel,
        BottomPanel1,
        BottomPanel2,
        ContinuePanel,
        StartPanel,
        RandomPanel,
        LvlPanel,
        WinOverPanel,
        WhoPanel,
        StatePanel,
        GoodPanel,
        BadPanel,
        HeroHpBarImage,
        MonsterHpBarImage;

        
    // Texts
    public Text ComboPointsText,
        HeroHpText,
        MonsterHpText,
        WhoseTurnText,
        GameOverText,
        WinBattleText,
        MonsterAttackLeftText,
        MonsterNameText,
        LvlUpText,
        ExpGiveText,
        GoldGiveText,
        MinusHeroText,
        MinusMonsterText;

    public void Reset_Text_Images()
    {
        // TEXTS //
           
        WhoseTurnText.enabled = false;
        WinBattleText.enabled = false;
        GameOverText.enabled = false;
        MonsterAttackLeftText.enabled = false;
        MinusHeroText.enabled = false;
        MinusMonsterText.enabled = false;

        // PANELS //

        BottomPanel1.enabled = true;
        BottomPanel2.enabled = true;
        ContinuePanel.enabled = false;
        StartPanel.enabled = true;
        RandomPanel.enabled = false;
        LvlPanel.enabled = false;
        WinOverPanel.enabled = false;
        StatePanel.enabled = false;
        GoodPanel.enabled = false;
        BadPanel.enabled = false;

    }


    public void OnStart()
    {
        OffRandomImages();
        OffTouchImages();
          
        // TEXTS //

        ComboPointsText.enabled = false;
        WhoseTurnText.enabled = false;
        WinBattleText.enabled = false;
        GameOverText.enabled = false;
        MonsterAttackLeftText.enabled = false;
        MonsterNameText.enabled = true;
        LvlUpText.enabled = false;
        ExpGiveText.enabled = false;
        GoldGiveText.enabled = false;
        MinusHeroText.enabled = false;
        MinusMonsterText.enabled = false;

        // PANELS //

        BottomPanel1.enabled = true;
        BottomPanel2.enabled = true;
        ContinuePanel.enabled = false;
        StartPanel.enabled = true;
        RandomPanel.enabled = false;
        LvlPanel.enabled = false;
        WinOverPanel.enabled = false;
        StatePanel.enabled = false;
        GoodPanel.enabled = false;
        BadPanel.enabled = false;
    }

    public void OnStartFight()
    {
        // TEXTS

        HeroHpText.enabled = true;
        MonsterHpText.enabled = true;
        WhoseTurnText.enabled = true;

        // PANELS //

        StartPanel.enabled = false;
        HpPanel.enabled = true;
        HpUpPanel.enabled = true;
        HpBetweenPanel.enabled = true;
        RandomPanel.enabled = true;
        WhoPanel.enabled = true;
        StatePanel.enabled = true;
       
    }

    public void HeroWin()
    {


    }

    public void HeroDead()
    {

    }

    public void UpdateHp()
    {

    }

    public void OffRandomImages()
    {
        DeltoidBlueImage.enabled = false;
        CircleBlueImage.enabled = false;
        SquareBlueImage.enabled = false;
        TriangleBlueImage.enabled = false;

        DeltoidGreenImage.enabled = false;
        CircleGreenImage.enabled = false;
        SquareGreenImage.enabled = false;
        TriangleGreenImage.enabled = false;

        DeltoidYellowImage.enabled = false;
        CircleYellowImage.enabled = false;
        SquareYellowImage.enabled = false;
        TriangleYellowImage.enabled = false;

        DeltoidBrownImage.enabled = false;
        CircleBrownImage.enabled = false;
        SquareBrownImage.enabled = false;
        TriangleBrownImage.enabled = false;
    }

    public void OffTouchImages()
    {   
        DeltoidTouch.enabled = false;
        CircleTouch.enabled = false;
        SquareTouch.enabled = false;
        TriangleTouch.enabled = false;
    }

    public void OnTouchImages()
    {
        DeltoidTouch.enabled = true;
        CircleTouch.enabled = true;
        SquareTouch.enabled = true;
        TriangleTouch.enabled = true;
    }

}
