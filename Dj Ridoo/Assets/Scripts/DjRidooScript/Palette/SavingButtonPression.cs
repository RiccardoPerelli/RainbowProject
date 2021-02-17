using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingButtonPression : ButtonPression
{
    public GameObject savingMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerAction();
        }
    }

    protected override void TriggerAction()
    {
        savingMenu.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
