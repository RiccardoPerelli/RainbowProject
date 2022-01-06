using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPassSliderInteraction : FilterSliderInteraction
{
	protected override void OnFrequencySliderValueChanged(float value)
	{
		foreach (var instrument in instruments)
		{
			instrument.GetComponent<AudioHighPassFilter>().cutoffFrequency = value * CUT_OFF_FREQUENCY_MAX_VALUE;
			if(frequenzaDiTaglio != null)
				frequenzaDiTaglio.text = "Frequenza di taglio: " + instrument.GetComponent<AudioHighPassFilter>().cutoffFrequency.ToString() + " HZ";
		}
	}

	protected override void OnResonanceSliderValueChanged(float value)
	{
		foreach (var instrument in instruments)
		{
			instrument.GetComponent<AudioHighPassFilter>().highpassResonanceQ = value * RESONANCE_MAX_VALUE;
			if (risonanza != null) 
				risonanza.text = "Risonanza: " + instrument.GetComponent<AudioHighPassFilter>().highpassResonanceQ.ToString();
		}
	}
}
