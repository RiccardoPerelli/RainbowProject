using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHandSword : MonoBehaviour
{
    bool switched;
    [SerializeField] private float noiseStrength = 0.25f;
    [SerializeField] private float objectHeight = 1.0f;

    public GameObject sword;
    public GameObject hand;
    public Material swordMat;
    public Material bladeMat;
    public Material handMat;

    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (handMat.GetFloat("_CutoffHeight")==0)
            switched = false;
        else if (sword.activeSelf)
            switched = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.A)))
        {
            if (switched == false)
            {
                sword.SetActive(true);
                //StartCoroutine("DeactiveHand");
                StartCoroutine(FadeHand(handMat, 0));
                StartCoroutine(FadeSword(bladeMat, swordMat, 3));
                switched = true;
            }
            else
            {
                StartCoroutine(FadeHand(handMat, 2));
                StartCoroutine(FadeSword(bladeMat, swordMat, 0));
                StartCoroutine("DeactiveSword");
                switched = false;
            }
        }
    }

    IEnumerator FadeHand(Material mat, float targetAlpha)
    {
        print("Entra in Fade");
        float height = hand.transform.position.y;
        while (mat.GetFloat("_CutoffHeight") != targetAlpha)
        {
            height = Mathf.MoveTowards(mat.GetFloat("_CutoffHeight"), targetAlpha, fadeSpeed * Time.deltaTime);
            SetHeight(mat, height);
            yield return null;
        }
    }

    IEnumerator FadeSword(Material mat1, Material mat2, float targetAlpha)
    {
        print("Entra in Fade");
        float height1 = sword.transform.position.y;
        float height2 = sword.transform.position.y;
        while (mat1.GetFloat("_CutoffHeight") != targetAlpha)
        {
            height1 = Mathf.MoveTowards(mat1.GetFloat("_CutoffHeight"), targetAlpha, fadeSpeed * Time.deltaTime);
            SetHeight(mat1, height1);
            height2 = Mathf.MoveTowards(mat2.GetFloat("_CutoffHeight"), targetAlpha, fadeSpeed * Time.deltaTime);
            SetHeight(mat2, height2);
            yield return null;
        }
    }

    IEnumerator DeactiveSword()
    {
        yield return new WaitForSeconds(5);
        sword.SetActive(false);
    }

    private void SetHeight(Material mat, float height)
    {
        mat.SetFloat("_CutoffHeight", height);
        mat.SetFloat("_NoiseStrength", noiseStrength);
    }
}
