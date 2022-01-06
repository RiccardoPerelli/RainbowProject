using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Microfone") != null)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("Microfone").transform.position;
            gameObject.transform.rotation = GameObject.FindGameObjectWithTag("Microfone").transform.rotation;
        } 
    }

}
