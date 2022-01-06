using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMap : MonoBehaviour
{
    private float delay = 2f;
    private Animator _animator;
    private AudioSource audioSource;

    public GameObject user;
    public float minDistance = 2f;

    private bool check = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator == null)
            return;

        if(Vector3.Distance(gameObject.transform.position, user.transform.position) <= minDistance)
        {
            _animator.SetBool("Open", true);
            if (check == false)
            {
                audioSource.Play();
                check = true;
            }
        }
        else
        {
            _animator.SetBool("Open", false);
            if(check == true)
            {
                audioSource.Play();
                check = false;
            }
        }
    }
}
