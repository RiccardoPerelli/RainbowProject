using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FilterSliderInteraction : SliderInteraction
{
	public const float RESONANCE_MAX_VALUE = 10f;
	public const float CUT_OFF_FREQUENCY_MAX_VALUE = 22000f;

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
		frequencySlider.value = cutOffFrequencyStartingValue / CUT_OFF_FREQUENCY_MAX_VALUE;
		risonanza.text = "Risonanza: " + resonanceStartingValue.ToString();
		resonanceSlider.value = resonanceStartingValue / RESONANCE_MAX_VALUE;

		//Adds a listener to the main slider and invokes a method when the value changes.
		frequencySlider.onValueChanged.AddListener(OnFrequencySliderValueChanged);
		resonanceSlider.onValueChanged.AddListener(OnResonanceSliderValueChanged);
	}

	protected virtual void OnFrequencySliderValueChanged(float value){ }

	protected virtual void OnResonanceSliderValueChanged(float value){ }

}
