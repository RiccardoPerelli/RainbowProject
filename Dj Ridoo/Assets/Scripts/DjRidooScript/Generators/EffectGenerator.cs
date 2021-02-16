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

    protected GameObject location;
    protected AudioSource thisAudioSource;

    private void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
        location = FindObjectOfType<LocationPlaceHolder>().gameObject;
    }

    private void applyEffect(Collision collision) { }

}
