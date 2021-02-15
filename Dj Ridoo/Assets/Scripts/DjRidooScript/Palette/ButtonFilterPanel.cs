using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFilterPanel : MonoBehaviour
{
    public GameObject emptyGameObject;
    public GameObject canvas;

    public void OnIntroduzioneClicked()
    {
        Debug.Log("Introduzione Clicked.");
        checkGameObjFil();
        //Instantiate(videoIntroduzione, emptyGameObject.transform);
    }

    public void OnLowClicked()
    {
        Debug.Log("LowPass Clicked.");
        checkGameObjFil();
        //Instantiate(videoLow, emptyGameObject.transform);
    }

    public void OnHighClicked()
    {
        Debug.Log("HighPass Clicked.");
        checkGameObjFil();
        //Instantiate(videoHigh, emptyGameObject.transform);
    }

    public void OnChorusClicked()
    {
        Debug.Log("Chorus Clicked.");
        checkGameObjFil();
        //Instantiate(videoChorus, emptyGameObject.transform);
    }

    public void OnEchoClicked()
    {
        Debug.Log("Echo Clicked.");
        checkGameObjFil();
        //Instantiate(videoEcho, emptyGameObject.transform);
    }

    public void OnBackFilClicked()
    {
        Debug.Log("Back Clicked.");
        gameObject.SetActive(false);
        canvas.SetActive(true);
    }

    private void checkGameObjFil()
    {
        Transform tf = emptyGameObject.GetComponentsInChildren<Transform>()[0];
        if (tf != null)
            Destroy(tf.gameObject);
    }
}
