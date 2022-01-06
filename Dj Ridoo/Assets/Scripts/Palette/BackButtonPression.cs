using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonPression : ButtonPression
{
    public GameObject PrincipalMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerAction();
        }
    }

    protected override void TriggerAction()
    {
        PrincipalMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
