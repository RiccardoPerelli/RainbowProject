using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectButtonPression : ButtonPression
{
    public GameObject objectToSpawn;

    protected override void TriggerAction()
    {
        Instantiate(objectToSpawn, location.transform.position, new Quaternion());
    }
}
