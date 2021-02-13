using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandSwordSimplified : MonoBehaviour
{

    public GameObject sword;

    bool switched = false;

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.A)))
        {
            if (switched == false)
            {
                sword.SetActive(true);
                //StartCoroutine("DeactiveHand");
                //StartCoroutine(FadeHand(handMat, 0));
                switched = true;
            }
            else
            {
                sword.SetActive(false);
                switched = false;
            }
        }
    }
}
