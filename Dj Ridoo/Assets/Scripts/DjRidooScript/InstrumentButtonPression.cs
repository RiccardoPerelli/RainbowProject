using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentButtonPression : ButtonPression
{
    public GameObject instrumentMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerAction();
        }
    }

    protected override void TriggerAction()
    {
        instrumentMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
