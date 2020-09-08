using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator transitionAnim;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void DoYouRealyWant()
    {
        StartCoroutine(SceneDoYouRealyWant());
    }

    public void ButtonNewGame()
    {
        PlayerPrefs.SetInt("HeroDex", 0);
        StartCoroutine(SceneNewGame());
    }

    public void ButtonContinueGame()
    {
        if(PlayerPrefs.GetInt("HeroDex") != 0)
        StartCoroutine(SceneContinueGame());
    }

    public void BackToMenu()
    {
        StartCoroutine(SceneToMenu());
    }

    public void Credits()
    {
        StartCoroutine(SceneToCredits());        
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("HeroDex", 0);
    }

    public void StoryScene()
    {
        StartCoroutine(SceneStory());
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    IEnumerator SceneToCredits()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Credits");
    }

    IEnumerator SceneStory()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("StoryScene");
    }

    IEnumerator SceneContinueGame()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MapVillage");
    }

    IEnumerator SceneToMenu()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator SceneNewGame()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MapVillage");
    }

    IEnumerator SceneDoYouRealyWant()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DoYouRealyWant");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}