using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastieraSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Tastiera") != null)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("Tastiera").transform.position;
            //gameObject.transform.rotation = GameObject.FindGameObjectWithTag("Tastiera").transform.rotation;
        }
    }
}
