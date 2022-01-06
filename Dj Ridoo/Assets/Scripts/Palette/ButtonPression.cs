using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class ButtonPression : MonoBehaviour
{
    public float zOffset = -120f;
    public float turnBackSpeed = 10f;

    protected float startingYValue;
    protected float startingXValue;
    protected GameObject pointer;

    private void Start()
    {
        startingYValue = gameObject.GetComponent<RectTransform>().anchoredPosition3D.y;
        startingXValue = gameObject.GetComponent<RectTransform>().anchoredPosition3D.x;
    }

    protected virtual void TriggerAction()
    {
        Debug.Log("BaseActionTriggered");
    }

    private void OnEnable()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(gameObject.GetComponent<RectTransform>().anchoredPosition3D.x,
            gameObject.GetComponent<RectTransform>().anchoredPosition3D.y, zOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Pointer"))
        {
            if(pointer == null)
            {
                pointer = other.gameObject;
            }
            if (pointer.GetComponent<PointerController>().touched)
            {
                gameObject.GetComponent<AudioSource>().Play(0);
                Debug.Log("clicked");
                TriggerAction();
                pointer.GetComponent<PointerController>().touched = false;
            }
        }
    }
}
