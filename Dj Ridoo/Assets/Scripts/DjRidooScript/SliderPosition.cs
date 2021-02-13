using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderPosition : MonoBehaviour
{
    public GameObject maxPosition;
    public GameObject minPosition;
    public Slider effectSlider;

    public float startingZPosition;
    public float startingXPosition;
    public float thisYPosition;

    private void Start()
    {
        startingZPosition = gameObject.transform.localPosition.z;
        startingXPosition = gameObject.transform.localPosition.x;
    }

    private void FixedUpdate()
    {
        gameObject.transform.localPosition = new Vector3(startingXPosition, gameObject.transform.localPosition.y, startingZPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.y < minPosition.gameObject.transform.localPosition.y)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, minPosition.gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        }
        else if (gameObject.transform.localPosition.y > maxPosition.gameObject.transform.localPosition.y)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, maxPosition.gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        }
        effectSlider.value = (gameObject.transform.localPosition.y - minPosition.gameObject.transform.localPosition.y) / 
            (maxPosition.gameObject.transform.localPosition.y - minPosition.gameObject.transform.localPosition.y);
    }
}
