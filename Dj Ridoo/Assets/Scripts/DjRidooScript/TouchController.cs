using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject fingerTip;

    protected bool isPointing;
    protected bool isTouching;
    protected Vector3 fingerTipForward;
    protected float touchDistance;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Awaked");
        fingerTipForward = fingerTip.transform.TransformDirection(Vector3.forward);
        touchDistance = 0.005f;
        isTouching = false;
        isPointing = false;
    }

    protected void CheckIfPointing()
    {
        if (!OVRInput.Get(OVRInput.NearTouch.SecondaryIndexTrigger))
        {
            isPointing = true;
        }
        else
        {
            isPointing = false;
        }
    }
}
