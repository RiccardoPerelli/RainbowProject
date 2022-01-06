using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EchoSliderInteraction : SliderInteraction
{

    public TextMeshProUGUI delayLevelText;
    public TextMeshProUGUI decayRatioLevelText;
    public TextMeshProUGUI wetMixLevelText;
    public TextMeshProUGUI dryMixLevelText;

    public Slider delaySlider;
    public Slider decayRatioSlider;
    public Slider wetMixSlider;
    public Slider dryMixSlider;

    public const int DELAY_LEVEL_MAX = 5000;
    public const float DECAY_RATIO_MAX = 1f;
    public const float WET_MIX_MAX = 1f;
    public const float DRY_MIX_MAX = 1f;

    public int delayLevelStartingValue = 500;
    public float decayRationStartingValue = 0.5f;
    public float wetMixStartingValue = 1f;
    public float dryMixStartingValue = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the value of the sliders
        if(delayLevelText != null)
            delayLevelText.text = "Livello delay: " + delayLevelStartingValue.ToString();
        if (decayRatioLevelText != null)
            decayRatioLevelText.text = "Decay ratio: " + decayRationStartingValue.ToString();
        if (wetMixLevelText != null)
            wetMixLevelText.text = "Wet mix: " + wetMixStartingValue.ToString();
        if (dryMixLevelText != null)
            dryMixLevelText.text = "Dry mix: " + dryMixStartingValue.ToString();

        delaySlider.value = delayLevelStartingValue / DELAY_LEVEL_MAX;
        decayRatioSlider.value = decayRationStartingValue / DECAY_RATIO_MAX;
        wetMixSlider.value = wetMixStartingValue / WET_MIX_MAX;
        dryMixSlider.value = dryMixStartingValue / DRY_MIX_MAX;

        //Adds a listener to the main sliders and invokes a method when the value changes.
        delaySlider.onValueChanged.AddListener(OnDelaySliderValueChanged);
        decayRatioSlider.onValueChanged.AddListener(OnDecayRatioSliderValueChanged);
        wetMixSlider.onValueChanged.AddListener(OnWetMixSliderValueChanged);
        dryMixSlider.onValueChanged.AddListener(OnDryMixSliderValueChanged);
    }

    protected void OnDelaySliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioEchoFilter>().delay = value * DELAY_LEVEL_MAX;
            if (delayLevelText != null)
                delayLevelText.text = "Livello delay: " + instrument.GetComponent<AudioEchoFilter>().delay.ToString();
        }
    }
    protected void OnDecayRatioSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioEchoFilter>().decayRatio = value * DECAY_RATIO_MAX;
            if (decayRatioLevelText != null)
                decayRatioLevelText.text = "Livello distorsione: " + instrument.GetComponent<AudioEchoFilter>().decayRatio.ToString();
        }
    }
    protected void OnWetMixSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioEchoFilter>().wetMix = value * WET_MIX_MAX;
            if (wetMixLevelText != null)
                wetMixLevelText.text = "Wet mix: " + instrument.GetComponent<AudioEchoFilter>().wetMix.ToString();
        }
    }
    protected void OnDryMixSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioEchoFilter>().dryMix = value * DRY_MIX_MAX;
            if (dryMixLevelText != null)
                dryMixLevelText.text = "Dry mix: " + instrument.GetComponent<AudioEchoFilter>().dryMix.ToString();
        }
    }
}
