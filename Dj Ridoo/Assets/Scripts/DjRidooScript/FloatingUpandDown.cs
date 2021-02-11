using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUpandDown : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float frequency = 0.5f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    bool floatup;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        } 
        else
        {
            posOffset = transform.position;
        }
    }
}
