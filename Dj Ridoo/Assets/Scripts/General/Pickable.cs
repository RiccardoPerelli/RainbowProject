using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    public GameObject objectToSpawn;

    protected void Start()
    {
        
    }

    public GameObject spawnObject()
    {
        return Instantiate(objectToSpawn, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
