﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightMover : MonoBehaviour
{
    private float delay = 2f;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Mover()
    {
        if (_animator == null)
            return;
        _animator.SetBool("makeMove", true);
    }

    public void UnMover()
    {
        if (_animator == null)
            return;
        _animator.SetBool("makeMove", false);
    }

    IEnumerator MakeMoveCo(float time)
    {
        Mover();
        yield return new WaitForSeconds(time);
        UnMover();
    }

    public void MakeMove()
    {
        StartCoroutine(MakeMoveCo(delay));
    }
}
