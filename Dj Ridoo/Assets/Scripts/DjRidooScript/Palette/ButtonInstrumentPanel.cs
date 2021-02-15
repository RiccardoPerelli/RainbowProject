using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInstrumentPanel : MonoBehaviour
{
    public GameObject emptyGameObject;
    public GameObject canvas;

    public void OnChitarraCClicked()
    {
        Debug.Log("Chitarra Classica Clicked.");
        checkGameObjIns();
        //Instantiate(videoChitarraC, emptyGameObject.transform);
    }

    public void OnChitarraEClicked()
    {
        Debug.Log("Chitarra Elettrica Clicked.");
        checkGameObjIns();
        //Instantiate(videoChitarraE, emptyGameObject.transform);
    }

    public void OnBatteriaClicked()
    {
        Debug.Log("Batteria Clicked.");
        checkGameObjIns();
        //Instantiate(videoBatteria, emptyGameObject.transform);
    }

    public void OnTastieraClicked()
    {
        Debug.Log("Tastiera Clicked.");
        checkGameObjIns();
        //Instantiate(videoTastiera, emptyGameObject.transform);
    }

    public void OnBackInsClicked()
    {
        Debug.Log("Back Clicked.");
        gameObject.SetActive(false);
        canvas.SetActive(true);
    }

    private void checkGameObjIns()
    {
        Transform tf = emptyGameObject.GetComponentsInChildren<Transform>()[0];
        if (tf != null)
            Destroy(tf.gameObject);
    }
}
