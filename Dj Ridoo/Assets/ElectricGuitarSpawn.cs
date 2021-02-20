using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricGuitarSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("ElectricGuitar") != null)
        {
            Debug.Log("Prendo la posizione!");
            Debug.Log(GameObject.FindGameObjectWithTag("ElectricGuitar").transform.rotation.eulerAngles.x);
            gameObject.transform.position = GameObject.FindGameObjectWithTag("ElectricGuitar").transform.position;
            gameObject.transform.rotation = GameObject.FindGameObjectWithTag("ElectricGuitar").transform.rotation;
        }
    }

}
