using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : MonoBehaviour
{

    public GameObject collidedObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Instrument") || other.gameObject.CompareTag("Filter"))
        {
            collidedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Instrument") || other.gameObject.CompareTag("Filter"))
        {
            collidedObject = null;
        }
    }

}
