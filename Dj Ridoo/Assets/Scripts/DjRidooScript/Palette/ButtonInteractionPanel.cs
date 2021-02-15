using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionPanel : MonoBehaviour
{

    public GameObject emptyGameObject;
    public GameObject instrumentCanvas;
    public GameObject filterCanvas;

    public void OnPaletteClicked()
    {
        Debug.Log("Palette Clicked.");
        checkGameObj();
        //Instantiate(videoPalette, emptyGameObject.transform);
    }

    public void OnInstrumentClicked()
    {
        Debug.Log("Strumenti Clicked.");
        gameObject.SetActive(false);
        instrumentCanvas.SetActive(true);
    }

    public void OnEffectClicked()
    {
        gameObject.SetActive(false);
        filterCanvas.SetActive(true);
        Debug.Log("Strumenti Clicked.");
    }

    public void OnSwordClicked()
    {
        Debug.Log("Sword Clicked.");
        checkGameObj();
        //Instantiate(videoSword, emptyGameObject.transform);
    }

    private void checkGameObj()
    {
        Transform tf = emptyGameObject.GetComponentsInChildren<Transform>()[0];
        if (tf != null)
            Destroy(tf.gameObject);
    }
}
