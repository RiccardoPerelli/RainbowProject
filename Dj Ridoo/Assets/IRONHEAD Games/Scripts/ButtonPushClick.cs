using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class ButtonPushClick : MonoBehaviour
{
    public float MinLocalY = 0.25f;
    public float MaxLocalY = 0.55f;
  
    public bool isBeingTouched = false;
    public bool isClicked = false;

    public Material greenMat;
    public Material redMat;

    public GameObject timeCountDownCanvas;
    public TextMeshProUGUI timeText;

    public Action OnButtonPressed;

    public float smooth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        // Start with button up top / popped up
        transform.localPosition = new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z);

        timeCountDownCanvas.SetActive(false);

    }

    private void Update()
    {
        Vector3 buttonDownPosition = new Vector3(transform.localPosition.x, MinLocalY, transform.localPosition.z);
        Vector3 buttonUpPosition = new Vector3(transform.localPosition.x, MaxLocalY, transform.localPosition.z);
        if (!isClicked)
        {
            if (!isBeingTouched && (transform.localPosition.y > MaxLocalY  || transform.localPosition.y < MaxLocalY))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, buttonUpPosition, Time.deltaTime * smooth);
            }

            if (transform.localPosition.y < MinLocalY)
            {
                isClicked = true;               
                transform.localPosition = buttonDownPosition;
                OnButtonDown();
            }
        }

        if(isClicked && transform.localPosition.y > MinLocalY)
        {
            isClicked = false;
            GetComponent<MeshRenderer>().material = redMat;
        }
      
    }


    void OnButtonDown()
    {
        GetComponent<MeshRenderer>().material = greenMat;
        //GetComponent<Collider>().isTrigger = true;
        OnButtonPressed();

        ////Playing Sound
        AudioManager.instance.buttonClickSound.gameObject.transform.position = transform.position;
        AudioManager.instance.buttonClickSound.Play();
      
    }

}
