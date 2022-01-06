﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUpandDown : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float frequency = 0.5f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private bool vibrationStarted = false;
    private GameObject grabbingObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        if (gameObject.transform.GetChild(0).gameObject.GetComponent<DistorsionSliderInteraction>() != null)
        {
            gameObject.transform.Rotate(-90, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        InitializeVibration();
    }

    private void InitializeVibration()
    {
        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed && !vibrationStarted)
        {
            grabbingObject = gameObject.GetComponent<OVRGrabbable>().grabbedBy.gameObject;
            vibrationStarted = !vibrationStarted;
            StartCoroutine(grabbingObject.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Medium, 0.3f));
        }
        else if (!gameObject.GetComponent<OVRGrabbable>().isGrabbed && vibrationStarted)
        {
            StartCoroutine(grabbingObject.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Hard, 0.3f));
            vibrationStarted = !vibrationStarted;
        }
    }
}
