﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haptics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject.tag == "Essence")
        {
            vibrateHand(0.3f);
        }
        if (coll.gameObject.tag == "Slider")
        {
            vibrateHand(0.3f);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Instrument")
        {
            vibrateHand(1);
        }

        if (coll.gameObject.tag == "Filter")
        {
            vibrateHand(0.5f);
        }
    }

    private void vibrateHand(float amplitude)
    {
        if (gameObject.tag == "LHand")
        {
            print("vibrazione mano sx");
            OVRInput.SetControllerVibration(1, amplitude, OVRInput.Controller.LTouch);
        }
            
        if (gameObject.tag == "RHand")
        {
            print("vibrazione mano dx");
            OVRInput.SetControllerVibration(1, amplitude, OVRInput.Controller.RTouch);
        }
    }
}
