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
        Debug.Log("Numero Linee: " + countCable);
        Debug.Log("Lunghezza SPoint: " + startPoint.Count);
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
                        print("Sword detected");
                        hitObjStart = startPoint[i];
                        startPoint.RemoveAt(i);
                        hitObjEnd = endPoint[i];
                        endPoint.RemoveAt(i);
                        hitObj = hit2.collider.gameObject;
                        hitObj.AddComponent<AudioSource>();
                        AudioSource sound = hitObj.GetComponent<AudioSource>();
                        sound.clip = swordHit;
                        sound.Play();
                        cutCheck = true;
                    }
                }
            }

		}
		if (cutCheck)
		{
			CutCable();
			cutCheck = false;
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
                    Debug.Log("referenza trova");
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

        CheckFilterType();

        Destroy(midPoint2, 5);
        Destroy(hitObjEnd);

        print(countCable);
        countCable--;

        if (countCable == -1)
            cutable = false;
    }

    private void CheckFilterType()
    {
        if (hitObjEnd.GetComponent<LowPassSliderInteraction>() != null)
        {
            Component component = hitObjStart.GetComponent<AudioLowPassFilter>();
            hitObjEnd.GetComponent<LowPassSliderInteraction>().RemoveObjectFromList(hitObjStart);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (hitObjEnd.GetComponent<HighPassSliderInteraction>() != null)
        {
            Component component = hitObjStart.GetComponent<AudioHighPassFilter>();
            hitObjEnd.GetComponent<HighPassSliderInteraction>().RemoveObjectFromList(hitObjStart);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (hitObjEnd.GetComponent<EchoSliderInteraction>() != null)
        {
            Component component = hitObjStart.GetComponent<AudioEchoFilter>();
            hitObjEnd.GetComponent<EchoSliderInteraction>().RemoveObjectFromList(hitObjStart);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (hitObjEnd.GetComponent<DistorsionSliderInteraction>() != null)
        {
            Component component = hitObjStart.GetComponent<AudioDistortionFilter>();
            hitObjEnd.GetComponent<DistorsionSliderInteraction>().RemoveObjectFromList(hitObjStart);
            Object.DestroyImmediate(component as Object, true);
        }
        else if (hitObjEnd.GetComponent<ChorusSliderInteraction>() != null)
        {
            Component component = hitObjStart.GetComponent<AudioChorusFilter>();
            hitObjEnd.GetComponent<ChorusSliderInteraction>().RemoveObjectFromList(hitObjStart);
            Object.DestroyImmediate(component as Object, true);
        }
    }
}

