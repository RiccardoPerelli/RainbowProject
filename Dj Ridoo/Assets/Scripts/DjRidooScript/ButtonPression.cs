using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class ButtonPression : MonoBehaviour
{
    public GameObject location;
    public float zOffset = -35f;
    public float turnBackSpeed = 10f;
    bool touching = false;

    protected float startingYValue;
    protected float startingXValue;
    protected GameObject pointer;

    private void Start()
    {
        startingYValue = gameObject.GetComponent<RectTransform>().anchoredPosition3D.y;
        startingXValue = gameObject.GetComponent<RectTransform>().anchoredPosition3D.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            CheckPosition();
        }
        else if (zOffset < gameObject.GetComponent<RectTransform>().anchoredPosition3D.z)
        {
            LerpPosition();
        }
    }

    private void LerpPosition()
    {
        float actualZ = gameObject.GetComponent<RectTransform>().anchoredPosition3D.z;
        float newZ = Mathf.Lerp(actualZ, zOffset, turnBackSpeed * Time.deltaTime);
        gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(startingXValue, startingYValue, newZ);
    }

    private void CheckPosition()
    {
        if (zOffset > gameObject.GetComponent<RectTransform>().anchoredPosition3D.z)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(startingXValue, startingYValue, zOffset);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(startingXValue, startingYValue,
                gameObject.GetComponent<RectTransform>().anchoredPosition3D.z);
        }
        if (gameObject.GetComponent<RectTransform>().anchoredPosition3D.z >= -10f)
        {
            TriggerAction();
            pointer.GetComponent<BoxCollider>().isTrigger = true;
            touching = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name.Equals("Pointer"))
        {
            if(pointer == null)
            {
                pointer = collision.collider.gameObject;
            }
            touching = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name.Equals("Pointer"))
        {
            touching = false;
        }
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
}
