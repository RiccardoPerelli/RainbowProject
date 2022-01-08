using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionTutorial : MonoBehaviour
{

    public string[] pages;
    int currentPage;

    void previousButtonAction()
    {
        //To-do: select previous page/text
        if(currentPage <= pages.Length)
        {
            return;
        }
        else
        {
            currentPage--;
            //to-do: cambiare testo del canvas con pages[currentPage]
        }
    }

    void nextButtonAction()
    {
        //To-do: select next page/Text
        if(currentPage >= pages.Length) 
        {
            return;
        }
        else
        {
            currentPage++;
            //to-do: cambiare testo del canvas con pages[currentPage]
        }
    }
}
