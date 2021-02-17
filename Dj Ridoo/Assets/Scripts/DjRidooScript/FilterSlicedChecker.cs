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
        if (mixer.transform.GetChild(0).GetComponent<LowPassSliderInteraction>() != null)
        {
            Destroy(gameObject.GetComponent<AudioLowPassFilter>());
        }
        else if (mixer.transform.GetChild(0).GetComponent<HighPassSliderInteraction>() != null)
        {
            Destroy(gameObject.GetComponent<AudioHighPassFilter>());
        }
        else if (mixer.transform.GetChild(0).GetComponent<DistorsionSliderInteraction>() != null)
        {
            Destroy(gameObject.GetComponent<AudioDistortionFilter>());
        }
        else if (mixer.transform.GetChild(0).GetComponent<EchoSliderInteraction>() != null)
        {
            Destroy(gameObject.GetComponent<AudioEchoFilter>());
        }
        else if (mixer.transform.GetChild(0).GetComponent<ChorusSliderInteraction>() != null)
        {
            Destroy(gameObject.GetComponent<AudioChorusFilter>());
        }
    }
}
