using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistorsionEffectGenerator : EffectGenerator
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Instrument")
        {
            Debug.Log("Collision Detected with the instrument");
            applyEffect(collision);
        }
        else if (collision.collider.gameObject.tag.Equals("Mixer") || collision.collider.gameObject.tag.Equals("Mixer"))
        {
            Debug.Log("Collision Detected");
            thisAudioSource.clip = doubleFilter;
            thisAudioSource.volume = 1.2f;
            thisAudioSource.Play();
            Destroy(this.gameObject, 3f);
            Destroy(this.gameObject, destroyTime);
        }
        else
        {
            Destroy(this.gameObject, destroyTime);
        }
    }

    private void applyEffect(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<AudioDistortionFilter>() == null)
        {
            GameObject expl = Instantiate(explosion, collision.collider.gameObject.transform.position, Quaternion.identity);
            Destroy(expl, 3); // delete the explosion after 3 seconds
            FindObjectOfType<LightMover>().MakeMove();
            GameObject gui = Instantiate(EffectUI, location.transform.position, Quaternion.identity) as GameObject;
            GameObject guiChild = gui.transform.GetChild(0).gameObject;
            collision.collider.gameObject.GetComponentInParent<ConnectingCables>().SpawnLinking(collision.collider.gameObject, guiChild);
            if (GameObject.FindGameObjectWithTag("Player") != null)
                gui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            guiChild.GetComponent<DistorsionSliderInteraction>().instruments.Add(collision.collider.gameObject);
            collision.collider.gameObject.AddComponent(typeof(AudioDistortionFilter));
            collision.collider.gameObject.GetComponent<AudioDistortionFilter>().distortionLevel = guiChild.GetComponent<DistorsionSliderInteraction>().distorsionLevelStartingValue;
            Destroy(this.gameObject, destroyTime);
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
