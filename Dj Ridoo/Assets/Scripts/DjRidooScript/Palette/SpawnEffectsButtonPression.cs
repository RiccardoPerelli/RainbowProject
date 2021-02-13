using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffectsButtonPression : ButtonPression
{
    public GameObject location;
    public GameObject objectToSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6) && objectToSpawn.name.Equals("Distorsion"))
        {
            TriggerAction();
        }
    }

    protected override void TriggerAction()
    {
        Instantiate(objectToSpawn, location.transform.position, new Quaternion());
    }
}
