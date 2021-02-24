using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotationSpeed = 10f;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
