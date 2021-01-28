using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPassFilterGenerator : EffectGenerator
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Instrument")
        {
            Debug.Log("Collision Detected with the instrument");
            applyEffect(collision);
        }
        else
        {
            Debug.Log("Collision Detected");
        }
    }

    private void applyEffect(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<AudioHighPassFilter>() == null)
        {
            GameObject gui = Instantiate(EffectUI, collision.collider.gameObject.transform.position + offset, Quaternion.identity) as GameObject;
            gui.GetComponent<HighPassSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioHighPassFilter));
            collision.collider.gameObject.GetComponent<AudioHighPassFilter>().highpassResonanceQ = gui.GetComponent<HighPassSliderInteraction>().resonanceStartingValue;
            collision.collider.gameObject.GetComponent<AudioHighPassFilter>().cutoffFrequency = gui.GetComponent<HighPassSliderInteraction>().cutOffFrequencyStartingValue;
        }
        else
        {
            Debug.Log("Effect already applied!");
        }
    }
}
