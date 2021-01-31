using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class ConnectingCables : MonoBehaviour
{
	#region Class members

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
		plug = Resources.Load<AudioClip>("plugIn");
		swordHit = Resources.Load<AudioClip>("sword");
	}


	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 2.0f))
        {
			if (Input.GetMouseButtonDown(1) && !firstClickCheck)
            {
				if (hit.collider.tag.Equals("Instrument"))
				{
					print("Individuato primo oggetto");
					startTmpObj = hit.collider.gameObject;
					startTmpObj.AddComponent<AudioSource>();
					AudioSource sound = startTmpObj.GetComponent<AudioSource>();
					sound.clip = plug;
					firstClickCheck = true;
					
					//TODO: sostituire con mano
					tmp = GameObject.Find("/InteractableFPSController/FirstPersonCamera");
					tmp.AddComponent<CableComponent>();
					tmp.GetComponent<CableComponent>().endPoint = startTmpObj.transform;
					tmp.GetComponent<CableComponent>().cableMaterial = cableMaterial;

					sound.Play();
				}
			}
			if (Input.GetMouseButtonDown(1) && firstClickCheck)
			{
				if (hit.collider.tag.Equals("Filter"))
				{
					print("Individuato secondo oggetto");
					endTmpObj = hit.collider.gameObject;
					firstClickCheck = false;
					render = true;
					Component component1 = tmp.GetComponent<CableComponent>();
					Object.DestroyImmediate(component1 as Object, true);
					Component component2 = tmp.GetComponent<LineRenderer>();
					Object.DestroyImmediate(component2 as Object, true);

					endTmpObj.AddComponent<AudioSource>();
					AudioSource sound = startTmpObj.GetComponent<AudioSource>();
					sound.clip = plug;
					sound.Play();
					firstClickCheck = false;
				}
			}
		}

        if (render)
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

	}

	void FixedUpdate()
    {
		for (int i = 0; i <= countCable && cutable; i++)
		{
			RaycastHit hit2;
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
		if (cutCheck)
		{
			CutCable();
			cutCheck = false;
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

	
	void SlicedCable(GameObject midPoint1, GameObject midPoint2)
    {
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

		print(countCable);
		countCable--;

		if(countCable == -1)
			cutable = false;
    }
}

