using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricGuitarSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        gameObject.transform.Rotate(0, 90f, 0);
    }
}
