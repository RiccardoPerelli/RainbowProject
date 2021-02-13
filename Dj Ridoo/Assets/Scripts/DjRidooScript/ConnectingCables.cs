using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class ConnectingCables : MonoBehaviour
{
	#region Class members

	public GameObject rightHandCollisionChecker;

	private List<GameObject> startPoint = new List<GameObject>();
	private List<GameObject> endPoint = new List<GameObject>();
	[SerializeField] private Material cableMaterial;
	private GameObject startTmpObj;
	private GameObject endTmpObj;

	//check for Rendering Cable
	private string firstClick = "";
	private bool firstClickCheck = false;
	private bool render = false;
	private bool cutable = false;
	private bool cutCheck = false;
	private bool initCut = false;

	private GameObject hitObjStart;
	private GameObject hitObjEnd;
	private GameObject hitObj;

	private GameObject tmp;

	private int countCable = -1;

	//Audio
	private AudioClip plug;
	private AudioClip swordHit;

	#endregion

	void Start()
	{
        Slicer.InstrumentSliced += DestroyInstrumentLink;
        plug = Resources.Load<AudioClip>("plugIn");
		swordHit = Resources.Load<AudioClip>("SliceSound");
	}


	void Update()
	{
        //Debug.Log("Numero Linee: " + countCable);
        //Debug.Log("Lunghezza SPoint: " + startPoint.Count);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 2.0f))
        //{
        if (OVRInput.GetDown(OVRInput.Button.One) && !firstClickCheck)
        {
			if(rightHandCollisionChecker.GetComponent<checkCollision>().collidedObject != null && 
				rightHandCollisionChecker.GetComponent<checkCollision>().collidedObject.tag.Equals("Instrument"))
            {
                checkStartingPoint();
            }
        }
		if (OVRInput.GetUp(OVRInput.Button.One) && firstClickCheck)
		{
			if (rightHandCollisionChecker.GetComponent<checkCollision>().collidedObject != null && 
				rightHandCollisionChecker.GetComponent<checkCollision>().collidedObject.tag.Equals("Filter"))
            {
                checkEndPoint();
            } else
            {
                DestroyLine();
            }
        }
		//}

        if (render)
        {
            RenderMultipleLine();
        }

    }

    private void DestroyLine()
    {
        Component component1 = rightHandCollisionChecker.GetComponent<CableComponent>();
        Object.DestroyImmediate(component1 as Object, true);
        Component component2 = rightHandCollisionChecker.GetComponent<LineRenderer>();
        Object.DestroyImmediate(component2 as Object, true);
        firstClickCheck = false;
    }

    private void checkStartingPoint()
    {
        print("Individuato primo oggetto");
        startTmpObj = rightHandCollisionChecker.GetComponent<checkCollision>().collidedObject;
        //startTmpObj.AddComponent<AudioSource>();
        //AudioSource sound = startTmpObj.GetComponent<AudioSource>();
        //sound.clip = plug;
        firstClickCheck = true;

        //TODO: sostituire con mano
        rightHandCollisionChecker.AddComponent<CableComponent>();
        rightHandCollisionChecker.GetComponent<CableComponent>().endPoint = startTmpObj.transform;
        rightHandCollisionChecker.GetComponent<CableComponent>().cableMaterial = cableMaterial;
        //tmp = GameObject.Find("/InteractableFPSController/FirstPersonCamera");
        //tmp.AddComponent<CableComponent>();
        //tmp.GetComponent<CableComponent>().endPoint = startTmpObj.transform;
        //tmp.GetComponent<CableComponent>().cableMaterial = cableMaterial;

        //sound.Play();
    }

    private void checkEndPoint()
    {
        print("Individuato secondo oggetto");
        endTmpObj = rightHandCollisionChecker.GetComponent<checkCollision>().collidedObject;
		if (endTmpObj.tag == startTmpObj.tag)
		{
			DestroyLine();
		}
		else
		{
			Component component1 = rightHandCollisionChecker.GetComponent<CableComponent>();
			Object.DestroyImmediate(component1 as Object, true);
			Component component2 = rightHandCollisionChecker.GetComponent<LineRenderer>();
			Object.DestroyImmediate(component2 as Object, true);

            if (endTmpObj.GetComponent<ChorusSliderInteraction>() != null)
            {
                FindObjectOfType<LightMover>().MakeMove();
                endTmpObj.GetComponent<ChorusSliderInteraction>().instruments.Add(startTmpObj);
                startTmpObj.AddComponent(typeof(AudioChorusFilter));
                startTmpObj.GetComponent<AudioChorusFilter>().dryMix = endTmpObj.GetComponent<ChorusSliderInteraction>().dryMixStartingValue;
                startTmpObj.GetComponent<AudioChorusFilter>().wetMix1 = endTmpObj.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
                startTmpObj.GetComponent<AudioChorusFilter>().wetMix2 = endTmpObj.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
                startTmpObj.GetComponent<AudioChorusFilter>().wetMix3 = endTmpObj.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
                startTmpObj.GetComponent<AudioChorusFilter>().delay = endTmpObj.GetComponent<ChorusSliderInteraction>().delayStartingValue;
                startTmpObj.GetComponent<AudioChorusFilter>().rate = endTmpObj.GetComponent<ChorusSliderInteraction>().rateStartingValue;
                startTmpObj.GetComponent<AudioChorusFilter>().depth = endTmpObj.GetComponent<ChorusSliderInteraction>().depthStartingValue;
            }
            else if (endTmpObj.GetComponent<EchoSliderInteraction>() != null)
            {
                FindObjectOfType<LightMover>().MakeMove();
                endTmpObj.GetComponent<EchoSliderInteraction>().instruments.Add(startTmpObj);
                startTmpObj.AddComponent(typeof(AudioEchoFilter));
                startTmpObj.GetComponent<AudioEchoFilter>().delay = endTmpObj.GetComponent<EchoSliderInteraction>().delayLevelStartingValue;
                startTmpObj.GetComponent<AudioEchoFilter>().decayRatio = endTmpObj.GetComponent<EchoSliderInteraction>().decayRationStartingValue;
                startTmpObj.GetComponent<AudioEchoFilter>().wetMix = endTmpObj.GetComponent<EchoSliderInteraction>().wetMixStartingValue;
                startTmpObj.GetComponent<AudioEchoFilter>().dryMix = endTmpObj.GetComponent<EchoSliderInteraction>().dryMixStartingValue;
            }
            else if (endTmpObj.GetComponent<LowPassSliderInteraction>() != null)
            {
                FindObjectOfType<LightMover>().MakeMove();
                endTmpObj.GetComponent<LowPassSliderInteraction>().instruments.Add(startTmpObj);
                startTmpObj.AddComponent(typeof(AudioLowPassFilter));
                startTmpObj.GetComponent<AudioLowPassFilter>().lowpassResonanceQ = endTmpObj.GetComponent<LowPassSliderInteraction>().resonanceStartingValue;
                startTmpObj.GetComponent<AudioLowPassFilter>().cutoffFrequency = endTmpObj.GetComponent<LowPassSliderInteraction>().cutOffFrequencyStartingValue;
            }
            else if (endTmpObj.GetComponent<HighPassSliderInteraction>() != null)
            {
                FindObjectOfType<LightMover>().MakeMove();
                endTmpObj.GetComponent<HighPassSliderInteraction>().instruments.Add(startTmpObj);
                startTmpObj.AddComponent(typeof(AudioHighPassFilter));
                startTmpObj.GetComponent<AudioHighPassFilter>().highpassResonanceQ = endTmpObj.GetComponent<LowPassSliderInteraction>().resonanceStartingValue;
                startTmpObj.GetComponent<AudioHighPassFilter>().cutoffFrequency = endTmpObj.GetComponent<LowPassSliderInteraction>().cutOffFrequencyStartingValue;
            }
            else if (endTmpObj.GetComponent<DistorsionSliderInteraction>() != null)
            {
                FindObjectOfType<LightMover>().MakeMove();
                endTmpObj.GetComponent<DistorsionSliderInteraction>().instruments.Add(startTmpObj);
                startTmpObj.AddComponent(typeof(AudioDistortionFilter));
                startTmpObj.GetComponent<AudioDistortionFilter>().distortionLevel = endTmpObj.GetComponent<DistorsionSliderInteraction>().distorsionLevelStartingValue;
            }

            //endTmpObj.AddComponent<AudioSource>();
            //AudioSource sound = startTmpObj.GetComponent<AudioSource>();
            //sound.clip = plug;
            //sound.Play();
            render = true;
			firstClickCheck = false;
		}
    }

    public void RenderMultipleLine()
    {
        print("Inizializzo collegamento");
        startPoint.Add(new GameObject("line" + startPoint.Count));
        countCable++;
        print(countCable);

        startPoint[countCable].transform.parent = startTmpObj.transform;
        startPoint[countCable].transform.position = startTmpObj.transform.position;

        endPoint.Add(new GameObject("line" + endPoint.Count));
        endPoint[countCable].transform.parent = endTmpObj.transform;
        endPoint[countCable].transform.position = endTmpObj.transform.position;

        startPoint[countCable].AddComponent<CableComponent>();
        startPoint[countCable].GetComponent<CableComponent>().endPoint = endPoint[countCable].transform;
        startPoint[countCable].GetComponent<CableComponent>().cableMaterial = cableMaterial;

        render = false;
        cutable = true;
    }

	public void SpawnLinking(GameObject startPoint, GameObject endPoint)
    {
		startTmpObj = startPoint;
		endTmpObj = endPoint;
		Debug.Log("Spawning Link!");
		RenderMultipleLine();
	}

    void FixedUpdate()
    {
		for (int i = 0; i <= countCable && cutable; i++)
		{
			RaycastHit hit2;
            if (startPoint[i] != null && endPoint[i] != null)
            {
                if (Physics.Raycast(startPoint[i].transform.position, endPoint[i].transform.position - startPoint[i].transform.position, out hit2))
                {
                    if (hit2.collider.tag.Equals("Sword"))
                    {
                        //print("Sword detected");
                        hitObjStart = startPoint[i];
                        startPoint.RemoveAt(i);
                        hitObjEnd = endPoint[i];
                        endPoint.RemoveAt(i);
                        CheckFilterType();
                        Debug.Log("Filter Check done!");
                        hitObj = hit2.collider.gameObject;
                        hitObj.AddComponent<AudioSource>();
                        AudioSource sound = hitObj.GetComponent<AudioSource>();
                        sound.clip = swordHit;
                        sound.Play();
                        cutCheck = true;
                    }
                }
            }
            if (cutCheck)
            {
                CutCable();
                i--;
                cutCheck = false;
            }
        }
	}

    public void DestroyInstrumentLink(GameObject instrument)
    {
        Debug.Log("instrument destroyed!");
        foreach (Transform child in instrument.transform)
        {
            for (int i = 0; i <= countCable; i++)
            {
                Debug.Log("instrument nome: " + child.name + " Start point nome: " + startPoint[i].name);
                if (child.name.Equals(startPoint[i].name))
                {
                    Debug.Log("referenza trovata");
                    Component component1 = startPoint[i].GetComponent<CableComponent>();
                    Object.DestroyImmediate(component1 as Object, true);
                    Component component2 = startPoint[i].GetComponent<LineRenderer>();
                    Object.DestroyImmediate(component2 as Object, true);
                    startPoint.RemoveAt(i);
                    Debug.Log("Distruggendo la linea");
                    endPoint.RemoveAt(i);
                    countCable--;
                    i--;
                }
            }
        }
    }
	
	void CutCable()
    {
		ResetLine();
		GameObject midPoint1 = AddMidPoint(hitObj.transform.position);
		GameObject midPoint2 = AddMidPoint(hitObj.transform.position);

		SlicedCable(midPoint1, midPoint2);
	}

	void ResetLine()
	{
		Component component1 = hitObjStart.GetComponent<CableComponent>();
		Object.DestroyImmediate(component1 as Object, true);
		Component component2 = hitObjStart.GetComponent<LineRenderer>();
		Object.DestroyImmediate(component2 as Object, true);
	}
	
	GameObject AddMidPoint(Vector3 position)
    {
		GameObject mid = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		mid.transform.position = position;
		mid.transform.localScale = new Vector3(.2f, .2f, .2f);
		mid.GetComponent<Renderer>().enabled = false;
		mid.AddComponent<Rigidbody>();
		mid.GetComponent<Rigidbody>().mass = 1f;

		return mid;
	}

	public void SlicedCable(GameObject midPoint1, GameObject midPoint2)
    {
        //todo: eliminare filtro dallo strumento e riferimento del filtro 
        hitObjStart.AddComponent<CableComponent>();
        hitObjStart.GetComponent<CableComponent>().endPoint = midPoint1.transform;
        hitObjStart.GetComponent<CableComponent>().cableMaterial = cableMaterial;

        Destroy(midPoint1, 5);
        Destroy(hitObjStart, 5);

        hitObjEnd.AddComponent<CableComponent>();
        hitObjEnd.GetComponent<CableComponent>().endPoint = midPoint2.transform;
        hitObjEnd.GetComponent<CableComponent>().cableMaterial = cableMaterial;

        Destroy(midPoint2, 5);
        Destroy(hitObjEnd);

        countCable--;

        if (countCable == -1)
            cutable = false;
    }

    private void CheckFilterType()
    {
        GameObject mixer = hitObjEnd.transform.parent.gameObject;
        GameObject instrument = hitObjStart.transform.parent.gameObject;
        Debug.Log(mixer.name);
        if (mixer.GetComponent<LowPassSliderInteraction>() != null)
        {
            Component component = instrument.GetComponent<AudioLowPassFilter>();
            mixer.GetComponent<LowPassSliderInteraction>().RemoveObjectFromList(instrument);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (mixer.GetComponent<HighPassSliderInteraction>() != null)
        {
            Component component = instrument.GetComponent<AudioHighPassFilter>();
            mixer.GetComponent<HighPassSliderInteraction>().RemoveObjectFromList(instrument);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (mixer.GetComponent<EchoSliderInteraction>() != null)
        {
            Component component = instrument.GetComponent<AudioEchoFilter>();
            mixer.GetComponent<EchoSliderInteraction>().RemoveObjectFromList(instrument);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (mixer.GetComponent<DistorsionSliderInteraction>() != null)
        {
            Debug.Log("Sliceando il cavo del distorsion!");
            Component component = instrument.GetComponent<AudioDistortionFilter>();
            mixer.GetComponent<DistorsionSliderInteraction>().RemoveObjectFromList(instrument);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (mixer.GetComponent<ChorusSliderInteraction>() != null)
        {
            Component component = instrument.GetComponent<AudioChorusFilter>();
            mixer.GetComponent<ChorusSliderInteraction>().RemoveObjectFromList(instrument);
            Object.DestroyImmediate(component as Object, true);
        }
    }
}

