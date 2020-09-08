using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextStoryScript : MonoBehaviour
{

    public float TextDelay = 0.06f;
    public Text FullText1, FullText2, FullText3, FullText4, FullText5;
    private bool Text1End, Text2End, Text3End, Text4End, Text5End;

    public string StringText1 { get; set; }
    public string StringText2 { get; set; }
    public string StringText3 { get; set; }
    public string StringText4 { get; set; }
    public string StringText5 { get; set; }

    private string CurrentText = "";
    public StoryScript StoryScript;

    void Start()
    {
        // Tekst do zmiany
        // 1 -> On przez tyle lat nie wzracał uwagi na to co robi Gromak patrzył tylko na to, że nie atakuje jego państwa i liczył na to, że nie zaatakuje ich
        // Jednak się przeliczył nawet na niego przyszła pora i Gromak wziął się za nich po tych latach stagnacji i nie robienia nic Gromak pokonał ich łatwo chodziaż
        // kiedyś byli uznawani za Kraj, którego nie da się pokonać bo władali specjalną techniką SuperCombo co umożliwiało im tworzenia bardzo wielu ciosów 
        // a przeciwnik nie miał się jak bronić, lecz nawet to nie pomogło im siły Gromaka były za duże. Może jest jeszcze jakaś nadzieja, żeby naprawić swoje błędy i
        // Postawić się Gromakowi.

        // Przez tyle lat patrzyłem jak Gromak i jego armie rosnął w siłę, choć inne kraje probowały 

        // Poprawić

        StringText1 = "  I was a great warrior while I must defend my country against a huge army of Gromak. " +
                      " He attacked us for many years but we fought off the enemy's attacks but the time has come. After many " +
                      " years of fight, Gromak beat us ";

        StringText2 = "  He enlisted me here to prison in the old dungeon. I spend 5 years in this place. Now after many years I " +
                      " got a chance to leave prison and get away from a dungeon ";

        // Poprawki 
        StringText3 = "  Last night came to me a strange person in a coat, he" +
                      " doesn't say anything but only give me a key, a letter and went away ";

        StringText4 = "  I read in the letter that only I have a chance to beat Gromak and make peace in this world." +
                     " Now when he gave me a key to prison I have no choice I must risk and try I don't think I will get another chance ";

        // Poprawić
        StringText5 = "  First, I must beat a lot of monsters to get to guards near the stairs. " +
                      " Let's kick some ass ";

        Text1End = false;
        Text2End = false;
        Text3End = false;
        Text4End = false;
        Text5End = false;

        StoryScript.ContinueButton.gameObject.SetActive(false);

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            if (StoryScript.Scene == 1 && Text1End != true)
            {
                for (int i = 2; i < StringText1.Length; i++)
                {
                    CurrentText = StringText1.Substring(0, i);
                    if(StringText1[i - 2] == '.')
                        yield return new WaitForSeconds(0.5f);
                    if (StringText1[i - 2] == ',')
                        yield return new WaitForSeconds(0.3f);
                    FullText1.GetComponent<Text>().text = CurrentText;
                    yield return new WaitForSeconds(TextDelay);
                }

                Text1End = true;
                StoryScript.CanIClickNext = true;
            }

            if (StoryScript.Scene == 2 && Text2End != true)
            {
                FullText1.enabled = false;
                yield return new WaitForSeconds(0.5f);
                for (int i = 2; i < StringText2.Length; i++)
                {
                    CurrentText = StringText2.Substring(0, i);
                    if (StringText2[i - 2] == '.')
                        yield return new WaitForSeconds(0.5f);
                    if (StringText2[i - 2] == ',')
                        yield return new WaitForSeconds(0.3f);
                    FullText2.GetComponent<Text>().text = CurrentText;
                    yield return new WaitForSeconds(TextDelay);
                }

                Text2End = true;
                StoryScript.CanIClickNext = true;
            }

            if (StoryScript.Scene == 3 && Text3End != true)
            {
                FullText2.enabled = false;
                yield return new WaitForSeconds(0.5f);
                for (int i = 2; i < StringText3.Length; i++)
                {
                    CurrentText = StringText3.Substring(0, i);
                    if (StringText3[i - 2] == '.')
                        yield return new WaitForSeconds(0.5f);
                    if (StringText3[i - 2] == ',')
                        yield return new WaitForSeconds(0.3f);
                    FullText3.GetComponent<Text>().text = CurrentText;
                    yield return new WaitForSeconds(TextDelay);
                    FullText1.enabled = false;
                }

                Text3End = true;
                StoryScript.CanIClickNext = true;
            }

            if (StoryScript.Scene == 4 && Text4End != true)
            {
                FullText3.enabled = false;
                yield return new WaitForSeconds(0.5f);
                for (int i = 2; i < StringText4.Length; i++)
                {
                    CurrentText = StringText4.Substring(0, i);
                    if (StringText4[i - 2] == '.')
                        yield return new WaitForSeconds(0.5f);
                    if (StringText4[i - 2] == ',')
                        yield return new WaitForSeconds(0.3f);
                    FullText4.GetComponent<Text>().text = CurrentText;
                    yield return new WaitForSeconds(TextDelay);
                }

                Text4End = true;
                StoryScript.CanIClickNext = true;

            }

            if (StoryScript.Scene == 5 && Text5End != true)
            {
                FullText4.enabled = false;
                StoryScript.NextButton.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                for (int i = 2; i < StringText5.Length; i++)
                {
                    CurrentText = StringText5.Substring(0, i);
                    if (StringText5[i - 2] == '.')
                        yield return new WaitForSeconds(0.5f);
                    if (StringText5[i - 2] == ',')
                        yield return new WaitForSeconds(0.3f);
                    FullText5.GetComponent<Text>().text = CurrentText;
                    yield return new WaitForSeconds(TextDelay);
                }

                Text5End = true;
                StoryScript.CanIClickNext = true;
                StoryScript.ContinueButton.gameObject.SetActive(true);
                
            }

            yield return null;
        }
    }


}
