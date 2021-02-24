using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Drums") != null)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("Drums").transform.position;
            gameObject.transform.rotation = GameObject.FindGameObjectWithTag("Drums").transform.rotation;
        }
    }

}
