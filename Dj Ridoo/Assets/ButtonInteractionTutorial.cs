using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteractionTutorial : MonoBehaviour
{

    public GameObject tutorialText;
    public GameObject tutorialButtonNext;
    public string[] pages;

    private TextMeshPro currentText;
    int currentPage;

    void Start()
    {
        currentPage = 0;
        tutorialText.GetComponent<TMP_Text>().text = pages[currentPage];
    }

    public void previousButtonAction()
    {
        if(currentPage == 0)
        {
            return;
        }
        else
        {
            currentPage--;
            tutorialText.GetComponent<TMP_Text>().text = pages[currentPage];
        }
    }

    public void nextButtonAction()
    {
        if (TutorialManager.tutorialStep == 0)
        {
            TutorialManager.tutorialStep++;
            Debug.Log("Primo step del tutorial " + TutorialManager.tutorialStep);
        }
        currentPage++;
        if(currentPage < pages.Length)
        {
            tutorialButtonNext.GetComponent<TMP_Text>().text = "Next";
            tutorialText.GetComponent<TMP_Text>().text = pages[currentPage];
        } 
        else if(currentPage == pages.Length && TutorialManager.tutorialStep == 4)
        {
            tutorialButtonNext.GetComponent<TMP_Text>().text = "Concert!";
        }
        else
        {
            if(TutorialManager.tutorialStep == 5)
            {
                SceneManager.LoadScene("Concert", LoadSceneMode.Single);
            }
            else
            {
                currentPage--;
            }
        }
    }
}
