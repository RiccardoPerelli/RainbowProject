using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PhysicsGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private AudioSource _audioSource;

    protected override void Start ()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        if(GetComponent<AudioSource>() != null)
            _audioSource = GetComponent<AudioSource>();
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        if(_audioSource != null)
            _audioSource.Pause();
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        if (_audioSource != null)
            _audioSource.Play();
    }
}
