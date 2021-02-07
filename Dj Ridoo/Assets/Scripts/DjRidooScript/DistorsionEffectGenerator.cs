using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistorsionEffectGenerator : EffectGenerator
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
        if (collision.collider.gameObject.GetComponent<AudioDistortionFilter>() == null)
        {
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            gui.GetComponent<DistorsionSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioDistortionFilter));
            collision.collider.gameObject.GetComponent<AudioDistortionFilter>().distortionLevel = gui.GetComponent<DistorsionSliderInteraction>().distorsionLevelStartingValue;
        }
        else
        {
            Debug.Log("Effect already applied!");
        }
    }
}
