using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInstrumentButtonPression : ButtonPression
{
    public GameObject location;
    public GameObject objectToSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5) && objectToSpawn.name.Equals("MiniGuitarEssence"))
        {
            TriggerAction();
        }
    }

    protected override void TriggerAction()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, location.transform.position, new Quaternion());
    }
}
