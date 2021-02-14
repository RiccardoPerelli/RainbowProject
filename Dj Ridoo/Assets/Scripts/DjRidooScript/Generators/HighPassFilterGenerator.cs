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
            Destroy(this.gameObject, destroyTime);
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
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(expl, 3); // delete the explosion after 3 seconds
            FindObjectOfType<LightMover>().MakeMove();
            Debug.Log("mixer is coming!");
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, gui);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
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
