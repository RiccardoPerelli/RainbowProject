using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class EffectGenerator : MonoBehaviour
{
    public GameObject EffectUI;
    public GameObject explosion;
    public float destroyTime;
    public AudioClip effectAlreadyApplied;
    public AudioClip doubleFilter; 

    protected GameObject location;
    protected AudioSource thisAudioSource;

    private bool vibrationStarted = false;
    private GameObject grabbingObject;


    private void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
        location = FindObjectOfType<LocationPlaceHolder>().gameObject;
    }

    private void Update()
    {
        if (gameObject.GetComponent<OVRGrabbable>().isGrabbed && !vibrationStarted)
        {
            grabbingObject = gameObject.GetComponent<OVRGrabbable>().grabbedBy.gameObject;
            vibrationStarted = !vibrationStarted;
            StartCoroutine(grabbingObject.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Hard, 0.6f));
        }
        else if (!gameObject.GetComponent<OVRGrabbable>().isGrabbed && vibrationStarted)
        {
            StartCoroutine(grabbingObject.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Hard, 0.3f));
            vibrationStarted = !vibrationStarted;
        }
    }

    private void applyEffect(Collision collision) { }

}
