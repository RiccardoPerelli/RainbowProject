using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : TouchController
{

    public GameObject effectPanel;
    public GameObject instrumentPanel;
    public GameObject savingPanel;

    // Update is called once per frame
    void Update()
    {
        CheckIfPointing();
        Debug.Log(Vector3.Distance(fingerTip.transform.position, transform.position));
        if(Physics.Raycast(fingerTip.transform.position, fingerTipForward, out RaycastHit ray, touchDistance))
        {
            Collider rayCollider = ray.collider;
            if (isPointing && !isTouching)
            {
                if (rayCollider.gameObject.tag.Equals("EffectButton"))
                {
                    Debug.Log("first button pressed!");
                    isTouching = true;
                    effectPanel.SetActive(true);
                    gameObject.SetActive(false);
                }
                else if (rayCollider.gameObject.tag.Equals("InstrumentButton"))
                {
                    Debug.Log("second button pressed!");
                    isTouching = true;
                    instrumentPanel.SetActive(true);
                    gameObject.SetActive(false);
                }
                else if (rayCollider.gameObject.tag.Equals("SaveButton"))
                {
                    Debug.Log("third button pressed!");
                    isTouching = true;
                    savingPanel.SetActive(true);
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
