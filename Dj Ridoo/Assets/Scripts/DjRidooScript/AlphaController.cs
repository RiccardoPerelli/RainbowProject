using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!OVRInput.Get(OVRInput.NearTouch.SecondaryIndexTrigger))
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }
}
