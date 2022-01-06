using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : TouchController
{
    public GameObject menuPanel;

    // Update is called once per frame
    void Update()
    {
        CheckIfPointing();
        Debug.Log(Vector3.Distance(fingerTip.transform.position, transform.position));
        if (Physics.Raycast(fingerTip.transform.position, fingerTipForward, out RaycastHit ray, touchDistance))
        {
            Collider rayCollider = ray.collider;
            if (isPointing && !isTouching)
            {
                if (rayCollider.gameObject.tag.Equals("FirstButton"))
                {
                    Debug.Log("first button pressed!");
                    isTouching = true;
                    //logica salvataggio
                }
                else if (rayCollider.gameObject.tag.Equals("SecondButton"))
                {
                    Debug.Log("second button pressed!");
                    isTouching = true;
                    //logica caricamento
                }
                else if (rayCollider.gameObject.tag.Equals("ThirdButton"))
                {
                    Debug.Log("third button pressed!");
                    isTouching = true;
                    menuPanel.SetActive(true);
                    gameObject.SetActive(false);
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
