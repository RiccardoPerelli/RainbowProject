using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class EffectGenerator : MonoBehaviour
{
    public GameObject EffectUI;
    public GameObject explosion;
    public float destroyTime;

    protected GameObject location;

    private void Start()
    {
        location = FindObjectOfType<LocationPlaceHolder>().gameObject;
    }

    private void applyEffect(Collision collision) { }

}
