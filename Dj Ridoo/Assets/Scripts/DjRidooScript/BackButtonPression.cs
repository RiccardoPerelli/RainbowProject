using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonPression : ButtonPression
{
    public GameObject PrincipalMenu;

    protected override void TriggerAction()
    {
        PrincipalMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
