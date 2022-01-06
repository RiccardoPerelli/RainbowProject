﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
public class LowPassSliderInteraction : FilterSliderInteraction
{
	protected override void OnFrequencySliderValueChanged(float value)
	{
		foreach (var instrument in instruments)
        {
			instrument.GetComponent<AudioLowPassFilter>().cutoffFrequency = value * CUT_OFF_FREQUENCY_MAX_VALUE;
			if (frequenzaDiTaglio != null)
                frequenzaDiTaglio.text = "Frequenza di taglio: " + instrument.GetComponent<AudioLowPassFilter>().cutoffFrequency.ToString() + " HZ";
		}
	}	

	protected override void OnResonanceSliderValueChanged(float value)
	{
		foreach (var instrument in instruments)
		{
			instrument.GetComponent<AudioLowPassFilter>().lowpassResonanceQ = value * RESONANCE_MAX_VALUE;
			if (risonanza != null)
                risonanza.text = "Risonanza: " + instrument.GetComponent<AudioLowPassFilter>().lowpassResonanceQ.ToString();
		}
	}

}
