using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsButtonPression : ButtonPression
{
    public GameObject effectMenu;

    protected override void TriggerAction()
    {
        effectMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
