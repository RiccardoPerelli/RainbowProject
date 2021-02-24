using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicGuitarSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("ClassicGuitar") != null)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("ClassicGuitar").transform.position;
            gameObject.transform.rotation = GameObject.FindGameObjectWithTag("ClassicGuitar").transform.rotation;
        }
    }

}
