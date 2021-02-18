using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    private void OnTriggerEnter(Collider other)
    {
        slicer.isTouched = true;
        OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.RTouch);
    }
}
