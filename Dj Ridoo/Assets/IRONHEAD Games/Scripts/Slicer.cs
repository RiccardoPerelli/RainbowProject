using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using System;

public class Slicer : MonoBehaviour
{

    public static event Action<GameObject> InstrumentSliced;
    public static event Action<GameObject> MixerSliced;
    public Material MaterialAfterSlice;
    public LayerMask sliceMask;
    public GameObject RightControllerAnchor;
    AudioSource audioData;

    public bool isTouched;

    //Instrument Destroy Effects
    public GameObject expl;
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {     
        if (isTouched == true)
        {
            isTouched = false;
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, MaterialAfterSlice);

                if (objectToBeSliced.gameObject != null && slicedObject != null)
                {
                    audioData.Play(0);
                    StartCoroutine(RightControllerAnchor.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Hard, 0.6f));
                    GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, MaterialAfterSlice);
                    GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, MaterialAfterSlice);
                    upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                    lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
                    if (InstrumentSliced != null && objectToBeSliced.gameObject.tag.Equals("Instrument"))
                    {
                        Debug.Log("Action Instrument Sliced Called");
                        GameObject explTmp = Instantiate(expl, objectToBeSliced.gameObject.transform.position, Quaternion.identity);
                        audioSource = explTmp.AddComponent<AudioSource>();
                        audioSource.clip = audioClip;
                        audioSource.Play();
                        Destroy(explTmp, 5.0f);
                        InstrumentSliced(objectToBeSliced.gameObject);
                    }
                    if(MixerSliced != null && objectToBeSliced.gameObject.tag.Equals("Mixer"))
                    {
                        Debug.Log("Action Filter Sliced Called");
                        MixerSliced(objectToBeSliced.gameObject);
                    }

                    MakeItPhysical(upperHullGameobject, objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity);
                    MakeItPhysical(lowerHullGameobject, objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity);
                }

                /*if (objectToBeSliced.gameObject.transform.childCount > 0){
                    Destroy(objectToBeSliced.gameObject.transform.GetChild(0).gameObject);
                }*/ 

                Destroy(objectToBeSliced.gameObject);
            }
        }

    }
    private void MakeItPhysical(GameObject obj, Vector3 _velocity)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().velocity = -_velocity;

        int randomNumberX = UnityEngine.Random.Range(0,2);
        int randomNumberY = UnityEngine.Random.Range(0, 2);
        int randomNumberZ = UnityEngine.Random.Range(0, 2);

        obj.GetComponent<Rigidbody>().AddForce(3*new Vector3(randomNumberX,randomNumberY,randomNumberZ),ForceMode.Impulse);       
        obj.AddComponent<DestroyAfterSeconds>();

    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

}
