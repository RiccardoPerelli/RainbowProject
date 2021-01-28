using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusEffectGenerator : EffectGenerator
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
        if (collision.collider.gameObject.GetComponent<AudioChorusFilter>() == null)
        {
            GameObject gui = Instantiate(EffectUI, collision.collider.gameObject.transform.position + offset, Quaternion.identity) as GameObject;

            gui.GetComponent<ChorusSliderInteraction>().instruments.Add(collision.collider.gameObject);

            collision.collider.gameObject.AddComponent(typeof(AudioChorusFilter));

            collision.collider.gameObject.GetComponent<AudioChorusFilter>().dryMix = gui.GetComponent<ChorusSliderInteraction>().dryMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix1 = gui.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix2 = gui.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix3 = gui.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().delay = gui.GetComponent<ChorusSliderInteraction>().delayStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().rate = gui.GetComponent<ChorusSliderInteraction>().rateStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().depth = gui.GetComponent<ChorusSliderInteraction>().depthStartingValue;
            //collision.collider.gameObject.GetComponent<AudioChorusFilter>().feedback = gui.GetComponent<ChorusSliderInteraction>().feedbackStartingValue;
        }
        else
        {
            Debug.Log("Effect already applied!");
        }
    }
}
