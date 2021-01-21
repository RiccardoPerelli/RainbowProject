using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenController : MonoBehaviour
{

    public GameObject fingerTip;
    public GameObject location;
    public GameObject cube;
    bool isPointing;
    bool isTouching;
    Vector3 fingerTipForward;
    float touchDistance;

    // Start is called before the first frame update
    void Start()
    {
        fingerTipForward = fingerTip.transform.TransformDirection(Vector3.forward);
        touchDistance = 0.005f;
        isTouching = false;
        isPointing = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPointing();

        if(Physics.Raycast(fingerTip.transform.position, fingerTipForward, out RaycastHit ray, touchDistance))
        {
            Collider rayCollider = ray.collider;
            if(rayCollider.gameObject.name.Equals("SoundButton1") && isPointing && !isTouching)
            {
                isTouching = true;
                Instantiate(cube, location.transform.position, new Quaternion(), gameObject.transform);
            }
            else
            {
                isTouching = false;
            }
        }
    }

    private void CheckIfPointing()
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
