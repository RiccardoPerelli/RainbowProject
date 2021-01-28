using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPassFilterGenerator : EffectGenerator
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Instrument")
        {
            Debug.Log("Collision Detected with the instrument");
            applyEffect(collision);
        } else
        {
            Debug.Log("Collision Detected");
        }
    }

    private void applyEffect(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<AudioLowPassFilter>() == null)
        {
            GameObject gui = Instantiate(EffectUI, collision.collider.gameObject.transform.position + offset, Quaternion.identity) as GameObject;
            gui.GetComponent<LowPassSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioLowPassFilter));
            collision.collider.gameObject.GetComponent<AudioLowPassFilter>().lowpassResonanceQ = gui.GetComponent<LowPassSliderInteraction>().resonanceStartingValue;
            collision.collider.gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = gui.GetComponent<LowPassSliderInteraction>().cutOffFrequencyStartingValue;
        } 
        else
        {
            Debug.Log("Effect already applied!");
        }
    }
}
