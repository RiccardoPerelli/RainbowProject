using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public static int tutorialStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.OnTutorialStep += TutorialUpdate;
    }

    void TutorialUpdate()
    {
        switch (tutorialStep)
        {
            case 0:
                EventManager.TutorialStep();
                //to-do Interaction with UI
                //fare la UI interagible con su delle pagine esplicative
                break;
            case 1:
                //to-do: guardare un video tutorial
                //inserire un video tutorial
                break;
            case 2:
                //to-do: utilizzare uno strumento
                break;
            case 3: 
                //to-do: Utilizzare un mixer
                break;
            case 4:
                //to-do: Manovrare i parametri del filtro
                break;

        }
        
        tutorialStep++;
    }
}
