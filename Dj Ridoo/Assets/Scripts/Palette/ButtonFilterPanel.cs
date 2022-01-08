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
        Debug.Log("Distortion Clicked.");
        checkGameObjFil();
        Instantiate(videoDistortion, emptyGameObject.transform);
    }

    public void OnLowClicked()
    {
        Debug.Log("LowPass Clicked.");
        checkGameObjFil();
        Instantiate(videoLow, emptyGameObject.transform);
    }

    public void OnHighClicked()
    {
        Debug.Log("HighPass Clicked.");
        checkGameObjFil();
        Instantiate(videoHigh, emptyGameObject.transform);
    }

    public void OnChorusClicked()
    {
        Debug.Log("Chorus Clicked.");
        checkGameObjFil();
        Instantiate(videoChorus, emptyGameObject.transform);
    }

    public void OnEchoClicked()
    {
        Debug.Log("Echo Clicked.");
        checkGameObjFil();
        Instantiate(videoEcho, emptyGameObject.transform);
    }

    public void OnBackFilClicked()
    {
        Debug.Log("Back Clicked.");
        gameObject.SetActive(false);
    }

    private void checkGameObjFil()
    {
        if (emptyGameObject.transform.childCount >= 1)
        {
            GameObject oldVideo = emptyGameObject.transform.GetChild(0).gameObject;
            Destroy(oldVideo.gameObject);
        }
    }
}
