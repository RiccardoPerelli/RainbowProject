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
        if (collision.collider.gameObject.GetComponent<AudioChorusFilter>() == null)
        {
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(expl, 3); // delete the explosion after 3 seconds
            Debug.Log("light mover starting!");
            FindObjectOfType<LightMover>().MakeMove();
            Debug.Log("light mover finishing!");
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            GameObject guiChild = gui.transform.GetChild(0).gameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, guiChild);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            guiChild.GetComponent<ChorusSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioChorusFilter));
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().dryMix = guiChild.GetComponent<ChorusSliderInteraction>().dryMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix1 = guiChild.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix2 = guiChild.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().wetMix3 = guiChild.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().delay = guiChild.GetComponent<ChorusSliderInteraction>().delayStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().rate = guiChild.GetComponent<ChorusSliderInteraction>().rateStartingValue;
            collision.collider.gameObject.GetComponent<AudioChorusFilter>().depth = guiChild.GetComponent<ChorusSliderInteraction>().depthStartingValue;
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
