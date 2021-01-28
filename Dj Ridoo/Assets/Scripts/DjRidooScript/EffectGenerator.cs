using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public abstract class EffectGenerator : MonoBehaviour
{
    public GameObject EffectUI;
    public Vector3 offset;
    public float destroyTime;
    public GameObject explosion;

    private void applyEffect(Collision collision) { }

}
