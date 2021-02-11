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
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            applyEffect(collision);
            Destroy(this.gameObject, destroyTime);
            Destroy(expl, 3); // delete the explosion after 3 seconds
        } else
        {
            Debug.Log("Collision Detected");
        }
    }

    private void applyEffect(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<AudioLowPassFilter>() == null)
        {
            Debug.Log("mixer is coming!");
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, gui);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
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
