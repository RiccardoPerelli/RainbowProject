using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInstrumentButtonPression : ButtonPression
{
    public GameObject location;
    public GameObject objectToSpawn;
    public GameObject cableHandler;

    protected override void TriggerAction()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, location.transform.position, new Quaternion());
        if(cableHandler != null)
            spawnedObject.transform.parent = cableHandler.transform;
    }
}
