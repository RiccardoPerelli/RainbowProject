using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPassFilterGenerator : EffectGenerator
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
        if (collision.collider.gameObject.tag == "Instrument")
        {
            Debug.Log("Collision Detected with the instrument detected");
            applyEffect(collision);
        }
    }

    private void applyEffect(Collision collision)
    {
        GameObject lwp = Instantiate(EffectUI, collision.collider.gameObject.transform.position + offset, Quaternion.identity) as GameObject;
        //Destroy(expl, 3); // delete the explosion after 3 seconds 
        lwp.GetComponent<SliderInteraction>().instruments.Add(collision.collider.gameObject);
        collision.collider.gameObject.AddComponent(typeof(AudioLowPassFilter));
        collision.collider.gameObject.GetComponent<AudioLowPassFilter>().lowpassResonanceQ = lwp.GetComponent<SliderInteraction>().resonanceStartingValue;
        collision.collider.gameObject.GetComponent<AudioLowPassFilter>().cutoffFrequency = lwp.GetComponent<SliderInteraction>().cutOffFrequencyStartingValue;
        Destroy(this.gameObject, destroyTime);
    }
}
