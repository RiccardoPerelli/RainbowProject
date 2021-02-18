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
		//Adds a listener to the main slider and invokes a method when the value changes.
		slider.onValueChanged.AddListener(OnSliderValueChanged);
	}

	public void OnSliderValueChanged(float value)
	{
		sliderValueText.text = value.ToString();
		parentObj.gameObject.GetComponent<AudioSource>().volume = value;
	}

}