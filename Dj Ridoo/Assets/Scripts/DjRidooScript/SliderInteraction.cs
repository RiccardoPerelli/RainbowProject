using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderInteraction : MonoBehaviour
{
    public TextMeshProUGUI frequenzaDiTaglio;
	public TextMeshProUGUI risonanza;

	public Slider frequencySlider;
	public Slider resonanceSlider;

	public List<GameObject> instruments;

	public float resonanceStartingValue = 5f;
	public float cutOffFrequencyStartingValue = 10000f;

	private AudioLowPassFilter lowPassFilter;

	public void Start()
	{
		//lowPassFilter = lowPass.GetComponent<AudioLowPassFilter>();
		frequenzaDiTaglio.text = "Frequenza di taglio: " + cutOffFrequencyStartingValue.ToString() + " HZ";
		frequencySlider.value = cutOffFrequencyStartingValue / 22000f;
		risonanza.text = "Risonanza: " + resonanceStartingValue.ToString();
		resonanceSlider.value = resonanceStartingValue / 10f;
		//Adds a listener to the main slider and invokes a method when the value changes.
		frequencySlider.onValueChanged.AddListener(OnFrequencySliderValueChanged);
		resonanceSlider.onValueChanged.AddListener(OnResonanceSliderValueChanged);
	}

	public void OnFrequencySliderValueChanged(float value)
	{
		foreach (var instrument in instruments)
        {
			instrument.GetComponent<AudioLowPassFilter>().cutoffFrequency = value * 22000f;
			frequenzaDiTaglio.text = "Frequenza di taglio: " + lowPassFilter.cutoffFrequency.ToString() + " HZ";
		}
	}	

	public void OnResonanceSliderValueChanged(float value)
	{
		foreach (var instrument in instruments)
		{
			instrument.GetComponent<AudioLowPassFilter>().lowpassResonanceQ = value * 10f;
			risonanza.text = "Risonanza: " + lowPassFilter.lowpassResonanceQ.ToString();
		}
	}

}
