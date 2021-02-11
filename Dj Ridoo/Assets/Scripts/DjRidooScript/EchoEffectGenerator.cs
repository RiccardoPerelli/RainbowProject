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
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            applyEffect(collision);
            Destroy(this.gameObject, destroyTime);
            Destroy(expl, 3); // delete the explosion after 3 seconds
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
            Debug.Log("mixer is coming!");
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, gui);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
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
