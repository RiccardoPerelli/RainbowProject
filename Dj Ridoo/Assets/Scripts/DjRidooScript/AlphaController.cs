using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour
{

    public GameObject alphaController;

    private Transform controllerTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        controllerTransform = alphaController.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alphaController.transform.rotation.z > 80)
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }
}
