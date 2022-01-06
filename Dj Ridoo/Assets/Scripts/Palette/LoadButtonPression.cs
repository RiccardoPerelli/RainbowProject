using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButtonPression : ButtonPression
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerAction();
        }
    }
    protected override void TriggerAction()
    {
        SavingManager.Instance.Load();
    }
}
