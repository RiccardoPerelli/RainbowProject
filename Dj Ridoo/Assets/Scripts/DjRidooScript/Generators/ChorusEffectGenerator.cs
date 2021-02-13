using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorusEffectGenerator : EffectGenerator
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Instrument"))
        {
            Debug.Log("Collision Detected with the instrument");
            Destroy(this.gameObject, destroyTime);
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
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(expl, 3); // delete the explosion after 3 seconds
            Debug.Log("light mover starting!");
            FindObjectOfType<LightMover>().MakeMove();
            Debug.Log("light mover finishing!");
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            Debug.Log("Spawning link!");
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, gui);
            Debug.Log("link spawned!");
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.rotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
            gui.GetComponent<ChorusSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioChorusFilter));
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().dryMix = gui.GetComponent<ChorusSliderInteraction>().dryMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix1 = gui.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix2 = gui.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix3 = gui.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().delay = gui.GetComponent<ChorusSliderInteraction>().delayStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().rate = gui.GetComponent<ChorusSliderInteraction>().rateStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().depth = gui.GetComponent<ChorusSliderInteraction>().depthStartingValue;
        }
        else
        {
            Debug.Log("Effect already applied!");
        }
    }

}
