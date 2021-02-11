using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteActivation : MonoBehaviour
{
    private Animator _animator;
    bool activated;
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
                Activate();
                activated = true;
            }
            else
            {
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
