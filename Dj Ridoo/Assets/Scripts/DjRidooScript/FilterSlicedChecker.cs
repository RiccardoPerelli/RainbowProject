using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterSlicedChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Slicer.MixerSliced += RemoveEffects;
    }
 
    private void RemoveEffects(GameObject mixer)
    {
        if (mixer.tag.Equals("LowPass"))
        {
            Destroy(gameObject.GetComponent<AudioLowPassFilter>());
        }
        else if (mixer.tag.Equals("HighPass"))
        {
            Destroy(gameObject.GetComponent<AudioHighPassFilter>());
        }
        else if (mixer.tag.Equals("Distorsion"))
        {
            Destroy(gameObject.GetComponent<AudioDistortionFilter>());
        }
        else if (mixer.tag.Equals("Echo"))
        {
            Destroy(gameObject.GetComponent<AudioEchoFilter>());
        }
        else if (mixer.tag.Equals("Chorus"))
        {
            Destroy(gameObject.GetComponent<AudioChorusFilter>());
        }
    }
}
