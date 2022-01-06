using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DistorsionSliderInteraction : SliderInteraction
{
    public TextMeshProUGUI distorsionLevelText;

    public Slider distorsionSlider;

    public const float DISTORSION_LEVEL_MAX = 1f;

    public float distorsionLevelStartingValue = 0.5f;

    public void Start()
    {
        //initialize the value of the slider
        if(distorsionLevelText != null)
            distorsionLevelText.text = "Livello distorsione: " + distorsionLevelStartingValue.ToString();

        distorsionSlider.value = distorsionLevelStartingValue / DISTORSION_LEVEL_MAX;

        //Adds a listener to the main slider and invokes a method when the value changes.
        distorsionSlider.onValueChanged.AddListener(OnDistorsionLevelSliderValueChanged);
    }

    protected void OnDistorsionLevelSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            if (instrument.GetComponent<AudioDistortionFilter>() != null)
            {
                instrument.GetComponent<AudioDistortionFilter>().distortionLevel = value * DISTORSION_LEVEL_MAX;
                if (distorsionLevelText != null)
                    distorsionLevelText.text = "Livello distorsione: " + instrument.GetComponent<AudioDistortionFilter>().distortionLevel.ToString();
            }
        }
    }
}
