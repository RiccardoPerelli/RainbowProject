using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsButtonPression : ButtonPression
{
    public GameObject effectMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerAction();
        }
    }

    protected override void TriggerAction()
    {
        effectMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
