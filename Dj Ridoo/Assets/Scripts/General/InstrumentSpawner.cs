using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSpawner : MonoBehaviour
{

    public GameObject instrumentToSpawn;
    public float destroyTime = 0.1f;
    public Vector3 offset;
    public Vector3 lookAtOffset;
    public int i = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Ground") && i == 0)
        {
            Debug.Log("Collision Detected with the ground");
            SpawnInstrument(collision);
        }
        else
        {
            Destroy(this.gameObject, destroyTime);
        }
    }

    private void SpawnInstrument(Collision collision)
    {
        FindObjectOfType<LightMover>().MakeMove();
        GameObject instrument = Instantiate(instrumentToSpawn, collision.GetContact(0).point + offset, Quaternion.identity,
            GameObject.FindGameObjectWithTag("CablesHandler").transform) as GameObject;
        if (instrument.GetComponent<IdChecker>() != null)
        {
            if (!instrument.GetComponent<IdChecker>().name.Equals("Drums") && 
                !instrument.GetComponent<IdChecker>().name.Equals("Microfone") && !instrument.GetComponent<IdChecker>().name.Equals("Tastiera"))
            {
                instrument.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            }
        }
        instrument.transform.Rotate(lookAtOffset);
        i++;
        Destroy(this.gameObject, destroyTime);
    }
}
