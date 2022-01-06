﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteActivation : MonoBehaviour
{
    private Animator _animator;
    bool activated;

    public GameObject menuPanel;
    public GameObject savingPanel;
    public GameObject instrumentPanel;
    public GameObject mixerPanel;

    void Start()
    {
        _animator = GetComponent<Animator>();
        activated = false;
    }

    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKeyDown(KeyCode.Alpha0)){
            if (!activated)
            {
                menuPanel.SetActive(true);
                savingPanel.SetActive(false);
                instrumentPanel.SetActive(false);
                mixerPanel.SetActive(false);
                Activate();
                activated = true;
            }
            else
            {
                if (menuPanel.activeSelf)
                {
                    menuPanel.SetActive(false);
                }  
                else if (savingPanel.activeSelf)
                {
                    menuPanel.SetActive(false);
                }
                else if (savingPanel.activeSelf)
                {
                    instrumentPanel.SetActive(false);
                }
                else if (savingPanel.activeSelf)
                {
                    mixerPanel.SetActive(false);
                }
                Deactivate();
                activated = false;
            }
                
        }
    }

    public void Activate()
    {
        if (_animator == null)
            return;
        _animator.SetBool("Active", true);
    }

    public void Deactivate()
    {
        if (_animator == null)
            return;
        _animator.SetBool("Active", false);
    }
}
