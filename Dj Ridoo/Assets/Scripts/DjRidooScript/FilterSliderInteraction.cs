using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FilterSliderInteraction : SliderInteraction
{
	public TextMeshProUGUI frequenzaDiTaglio;
	public TextMeshProUGUI risonanza;

	public Slider frequencySlider;
	public Slider resonanceSlider;

	public float resonanceStartingValue = 5f;
	public float cutOffFrequencyStartingValue = 10000f;

	public void Start()
	{
		//initialize the value of the slider
		frequenzaDiTaglio.text = "Frequenza di taglio: " + cutOffFrequencyStartingValue.ToString() + " HZ";
		frequencySlider.value = cutOffFrequencyStartingValue / 22000f;
		risonanza.text = "Risonanza: " + resonanceStartingValue.ToString();
		resonanceSlider.value = resonanceStartingValue / 10f;

		//Adds a listener to the main slider and invokes a method when the value changes.
		frequencySlider.onValueChanged.AddListener(OnFrequencySliderValueChanged);
		resonanceSlider.onValueChanged.AddListener(OnResonanceSliderValueChanged);
	}

	protected virtual void OnFrequencySliderValueChanged(float value){ }

	protected virtual void OnResonanceSliderValueChanged(float value){ }

}
