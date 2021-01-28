using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffectGenerator : EffectGenerator
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
        if (collision.collider.gameObject.GetComponent<AudioEchoFilter>() == null)
        {
            GameObject gui = Instantiate(EffectUI, collision.collider.gameObject.transform.position + offset, Quaternion.identity) as GameObject;
            gui.GetComponent<EchoSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioEchoFilter));
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().delay = gui.GetComponent<EchoSliderInteraction>().delayLevelStartingValue;
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().decayRatio = gui.GetComponent<EchoSliderInteraction>().decayRationStartingValue;
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().wetMix = gui.GetComponent<EchoSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().dryMix = gui.GetComponent<EchoSliderInteraction>().dryMixStartingValue;
        }
        else
        {
            Debug.Log("Effect already applied!");
        }
    }
}
