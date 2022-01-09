using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFilterPanel : MonoBehaviour
{
    public GameObject emptyGameObject;
    public GameObject videoDistortion;
    public GameObject videoLow;
    public GameObject videoHigh;
    public GameObject videoChorus;
    public GameObject videoEcho;

    public void OnDistortionClicked()
    {
        checkGameObjFil();
        checkTutorialStep();
        Instantiate(videoDistortion, emptyGameObject.transform);
    }

    public void OnLowClicked()
    {
        checkGameObjFil();
        checkTutorialStep();
        Instantiate(videoLow, emptyGameObject.transform);
    }

    public void OnHighClicked()
    {
        checkGameObjFil();
        checkTutorialStep();
        Instantiate(videoHigh, emptyGameObject.transform);
    }

    public void OnChorusClicked()
    {
        checkGameObjFil();
        checkTutorialStep();
        Instantiate(videoChorus, emptyGameObject.transform);
    }

    public void OnEchoClicked()
    {
        checkGameObjFil();
        checkTutorialStep();
        Instantiate(videoEcho, emptyGameObject.transform);
    }

    private void checkGameObjFil()
    {
        if (emptyGameObject.transform.childCount >= 1)
        {
            GameObject oldVideo = emptyGameObject.transform.GetChild(0).gameObject;
            Destroy(oldVideo.gameObject);
        }
    }

    private void checkTutorialStep()
    {
        if(TutorialManager.tutorialStep == 1)
        {
            TutorialManager.tutorialStep++;
        }
    }
}
