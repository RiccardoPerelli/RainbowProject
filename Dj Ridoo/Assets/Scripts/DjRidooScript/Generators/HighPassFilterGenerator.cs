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
            Destroy(this.gameObject, destroyTime);
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
            GameObject guiChild = gui.transform.GetChild(0).gameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, guiChild);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            guiChild.GetComponent<HighPassSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioHighPassFilter));
            collision.collider.gameObject.GetComponent<AudioHighPassFilter>().highpassResonanceQ = guiChild.GetComponent<HighPassSliderInteraction>().resonanceStartingValue;
            collision.collider.gameObject.GetComponent<AudioHighPassFilter>().cutoffFrequency = guiChild.GetComponent<HighPassSliderInteraction>().cutOffFrequencyStartingValue;
            Destroy(this.gameObject, destroyTime);
        }
        else
        {
            Debug.Log("Effect already applied!");
            thisAudioSource.clip = effectAlreadyApplied;
            thisAudioSource.volume = 1.2f;
            thisAudioSource.Play();
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            Destroy(this.gameObject, 3f);
        }
    }
}
