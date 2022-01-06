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
        else if (collision.collider.gameObject.tag.Equals("Mixer") || collision.collider.gameObject.tag.Equals("Filter"))
        {
            Debug.Log("Collision Detected");
            thisAudioSource.clip = doubleFilter;
            thisAudioSource.volume = 1.2f;
            thisAudioSource.Play();
            Destroy(this.gameObject, 3f);
        }
        else
        {
            Destroy(this.gameObject, destroyTime);
        }
    }

    private void applyEffect(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<AudioEchoFilter>() == null)
        {
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(expl, 3); // delete the explosion after 3 seconds
            FindObjectOfType<LightMover>().MakeMove();
            Debug.Log("mixer is coming!");
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            GameObject guiChild = gui.transform.GetChild(0).gameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, guiChild);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            guiChild.GetComponent<EchoSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioEchoFilter));
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().delay = guiChild.GetComponent<EchoSliderInteraction>().delayLevelStartingValue;
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().decayRatio = guiChild.GetComponent<EchoSliderInteraction>().decayRationStartingValue;
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().wetMix = guiChild.GetComponent<EchoSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioEchoFilter>().dryMix = guiChild.GetComponent<EchoSliderInteraction>().dryMixStartingValue;
        }
        else
        {
            Debug.Log("Effect already applied!");
            thisAudioSource.clip = effectAlreadyApplied;
            thisAudioSource.volume = 1.2f;
            thisAudioSource.Play();
            Destroy(this.gameObject, 3f);
        }
    }
}
