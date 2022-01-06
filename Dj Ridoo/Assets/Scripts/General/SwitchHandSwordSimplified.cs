using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandSwordSimplified : MonoBehaviour
{

    public GameObject RightControllerAnchor;
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
                switched = true;
                StartCoroutine(RightControllerAnchor.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Light, 0.3f));
            }
            else
            {
                StartCoroutine(RightControllerAnchor.GetComponent<OculusHaptics>().VibrateTime(VibrationForce.Light, 0.3f));
                sword.SetActive(false);
                switched = false;
            }
        }
    }
}
