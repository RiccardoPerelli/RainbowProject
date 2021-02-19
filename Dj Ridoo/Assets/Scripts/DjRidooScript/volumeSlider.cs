using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour
{
	public TextMeshProUGUI sliderValueText;

	public Slider slider;

	private Transform parentObj;

	public void Start()
	{
		sliderValueText.text = slider.value.ToString();
		parentObj = gameObject.transform.parent;
		slider.value = parentObj.gameObject.GetComponent<AudioSource>().volume;
	}

	void FixedUpdate()
    {
		sliderValueText.text = slider.value.ToString("N2");
		print(slider.value);
		parentObj.gameObject.GetComponent<AudioSource>().volume = slider.value;
	}

}