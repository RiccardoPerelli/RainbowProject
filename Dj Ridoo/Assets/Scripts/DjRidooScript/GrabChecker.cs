using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabChecker : MonoBehaviour
{

    private AudioSource thisAudio;

    // Start is called before the first frame update
    void Start()
    {
        thisAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisAudio != null)
        {
            if (gameObject.GetComponent<OVRGrabbable>().isGrabbed)
            {
                thisAudio.Stop();
            }
            else if(!thisAudio.isPlaying)
            {
                thisAudio.Play();
            }
        }
    }


}
