using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenController : TouchController
{

    public GameObject location;
    public GameObject firstPrefab;
    public GameObject secondPrefab;
    public GameObject thirdPrefab;
    public GameObject fourthPrefab;
    public GameObject fifthPrefab;
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        CheckIfPointing();

        if (Physics.Raycast(fingerTip.transform.position, fingerTipForward, out RaycastHit ray, touchDistance))
        {
            Collider rayCollider = ray.collider;
            if (isPointing && !isTouching)
            {
                if (rayCollider.gameObject.tag.Equals("FirstButton"))
                {
                    Debug.Log("first button pressed!");
                    isTouching = true;
                    Instantiate(firstPrefab, location.transform.position, new Quaternion());
                } 
                else if (rayCollider.gameObject.tag.Equals("SecondButton"))
                {
                    Debug.Log("second button pressed!");
                    isTouching = true;
                    Instantiate(secondPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.tag.Equals("ThirdButton"))
                {
                    Debug.Log("third button pressed!");
                    isTouching = true;
                    Instantiate(thirdPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.tag.Equals("FourthButton"))
                {
                    Debug.Log("fourth button pressed!");
                    isTouching = true;
                    Instantiate(fourthPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.tag.Equals("FifthButton"))
                {
                    Debug.Log("fifth button pressed!");
                    isTouching = true;
                    Instantiate(fifthPrefab, location.transform.position, new Quaternion());
                }
                else if (rayCollider.gameObject.tag.Equals("BackButton"))
                {
                    isTouching = false;
                    isPointing = false;
                    gameObject.SetActive(false);
                    menu.SetActive(true);
                }
            }
            else if (Vector3.Distance(fingerTip.transform.position, transform.position) >= 0.1f)
            {
                Debug.Log("can Touch!");
                isTouching = false;
            }
        }
    }

}
