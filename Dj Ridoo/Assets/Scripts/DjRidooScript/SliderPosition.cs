using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderPosition : MonoBehaviour
{
    public GameObject maxPosition;
    public GameObject minPosition;
    public Slider effectSlider;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < minPosition.gameObject.transform.position.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, minPosition.gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.y > maxPosition.gameObject.transform.position.y)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, maxPosition.gameObject.transform.position.y, gameObject.transform.position.z);
        }
        effectSlider.value = (gameObject.transform.position.y - minPosition.gameObject.transform.position.y) / 
            (maxPosition.gameObject.transform.position.y - minPosition.gameObject.transform.position.y);
    }
}
