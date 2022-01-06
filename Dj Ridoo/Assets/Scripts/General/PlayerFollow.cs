using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
            transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
    }

}
