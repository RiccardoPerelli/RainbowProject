using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    public bool isActive = true;
    public GameObject palette;
    public float reactivationDistance = 0.24f;

    private void Update()
    {
        Debug.Log("Distance is: " + Vector3.Distance(gameObject.transform.position, palette.transform.position));
        if (palette.activeSelf)
        {
            if(Vector3.Distance(gameObject.transform.position, palette.transform.position) > reactivationDistance && GetComponent<BoxCollider>().isTrigger)
            {
                GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }

}
