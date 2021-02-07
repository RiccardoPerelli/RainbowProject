using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandSword : MonoBehaviour
{
    bool switched;
    GameObject hand;
    GameObject sword;

    public Material swordMat;
    public Material bladeMat;
    public Material handMat;

    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        switched = false;
        sword = GameObject.FindWithTag("Sword");
        hand = GameObject.FindWithTag("Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (switched == false)
            {
                sword.SetActive(true);
                StartCoroutine(Fade(handMat, 0));
                StartCoroutine(Fade(bladeMat, 1));
                StartCoroutine(Fade(swordMat, 1));
                StartCoroutine("DeactiveHand");
                switched = true;
            }
            else
            {
                hand.SetActive(true);
                StartCoroutine(Fade(handMat, 1));
                StartCoroutine(Fade(bladeMat, 0));
                StartCoroutine(Fade(swordMat, 0));
                StartCoroutine("DeactiveSword");
                switched = false;
            }
        }
    }

    IEnumerator Fade(Material mat, float targetAlpha)
    {
        print("Entra in Fade");
        while (mat.color.a != targetAlpha)
        {
            Color c = mat.color;
            var newAlpha = Mathf.MoveTowards(mat.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, newAlpha); ;
            yield return null;
        }
    }

    IEnumerator DeactiveHand()
    {
        yield return new WaitForSeconds(2);
        hand.SetActive(false);
    }

    IEnumerator DeactiveSword()
    {
        yield return new WaitForSeconds(2);
        sword.SetActive(false);
    }
}
