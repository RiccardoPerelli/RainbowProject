using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenController : MonoBehaviour
{

    public GameObject fingerTip;
    public GameObject location;
    public GameObject lowPassFilterPrefab;
    public GameObject highPassFilterPrefab;
    public GameObject chorusEffectPrefab;
    public GameObject distorsionEffectPrefab;
    public GameObject echoEffectEffectPrefab;
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
            if (isPointing && !isTouching)
            {
                if (rayCollider.gameObject.name.Equals("LowPassFilterBtn"))
                {
                    Debug.Log("Low Pass Button pressed!");
                    isTouching = true;
                    Instantiate(lowPassFilterPrefab, location.transform.position, new Quaternion());
                } 
                else if (rayCollider.gameObject.name.Equals("HighPassFilterBtn"))
                {
                    Debug.Log("High Pass Button pressed!");
                    isTouching = true;
                    Instantiate(highPassFilterPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.name.Equals("ChorusEffectBtn"))
                {
                    Debug.Log("Chorus Button pressed!");
                    isTouching = true;
                    Instantiate(chorusEffectPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.name.Equals("DistorsionEffectBtn"))
                {
                    Debug.Log("Distorsion Button pressed!");
                    isTouching = true;
                    Instantiate(distorsionEffectPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.name.Equals("EchoEffectBtn"))
                {
                    Debug.Log("Echo Button pressed!");
                    isTouching = true;
                    Instantiate(echoEffectEffectPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.name.Equals("BackBtn"))
                {
                    isTouching = true;
                    //Todo: back on the palette
                }
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
