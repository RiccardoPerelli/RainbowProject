using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractionPanel : MonoBehaviour
{

    public GameObject emptyGameObject;
    public GameObject videoInstrument;
    public GameObject filterCanvas;
    public GameObject videoPalette;
    public GameObject videoSword;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnPaletteClicked();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnSwordClicked();
        }
    }

    public void OnPaletteClicked()
    {
        Debug.Log("Palette Clicked.");
        checkGameObj();
        Instantiate(videoInstrument, emptyGameObject.transform);
    }

    public void OnInstrumentClicked()
    {
        Debug.Log("Strumenti Clicked.");
        checkGameObj();
        Instantiate(videoPalette, emptyGameObject.transform);
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
        Instantiate(videoSword, emptyGameObject.transform);
    }

    private void checkGameObj()
    {
        if (emptyGameObject.transform.childCount >= 1)
        {
            GameObject oldVideo = emptyGameObject.transform.GetChild(0).gameObject;
            Destroy(oldVideo.gameObject);
        }
    }
}
