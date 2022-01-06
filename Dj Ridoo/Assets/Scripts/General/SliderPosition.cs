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
    public float sliderValue;

    private void Start()
    {
        startingZPosition = gameObject.transform.localPosition.z;
        startingXPosition = gameObject.transform.localPosition.x;
        float newY = (maxPosition.gameObject.transform.localPosition.y - minPosition.gameObject.transform.localPosition.y) * sliderValue + minPosition.gameObject.transform.localPosition.y;
        gameObject.transform.localPosition = new Vector3(startingXPosition, newY, startingZPosition);
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
            gameObject.transform.localPosition = new Vector3(startingXPosition, minPosition.gameObject.transform.localPosition.y, startingZPosition);
        }
        else if (gameObject.transform.localPosition.y > maxPosition.gameObject.transform.localPosition.y)
        {
            gameObject.transform.localPosition = new Vector3(startingXPosition, maxPosition.gameObject.transform.localPosition.y, startingZPosition);
        }
        sliderValue = (gameObject.transform.localPosition.y - minPosition.gameObject.transform.localPosition.y) /
            (maxPosition.gameObject.transform.localPosition.y - minPosition.gameObject.transform.localPosition.y);
        effectSlider.value = sliderValue;
    }
}
