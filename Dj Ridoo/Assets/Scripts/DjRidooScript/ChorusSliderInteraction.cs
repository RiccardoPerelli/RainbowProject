using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChorusSliderInteraction : SliderInteraction
{

    public TextMeshProUGUI dryMixText;
    public TextMeshProUGUI wetMixTap1Text;
    public TextMeshProUGUI wetMixTap2Text;
    public TextMeshProUGUI wetMixTap3Text;
    public TextMeshProUGUI delayText;
    public TextMeshProUGUI rateText;
    public TextMeshProUGUI depthText;
    public TextMeshProUGUI feedbackText;

    public Slider dryMixSlider;
    public Slider wetMix1Slider;
    public Slider wetMix2Slider;
    public Slider wetMix3Slider;
    public Slider delaySlider;
    public Slider rateSlider;
    public Slider depthSlider;
    public Slider feedbackSlider;

    public const float DRY_MIX_MAX = 1f;
    public const float WET_MIX_MAX = 1f;
    public const float DELAY_MAX = 100f;
    public const float RATE_MAX = 1f;
    public const float DEPTH_MAX = 1f;
    public const float FEEDBACK_MAX = 1f;

    public float dryMixStartingValue = 0.5f;
    public float wetMixStartingValue = 0.5f;
    public float delayStartingValue = 40f;
    public float rateStartingValue = 0.8f;
    public float depthStartingValue = 0.3f;
    public float feedbackStartingValue = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize the value of the slider
        dryMixText.text     = "Dry Mix: "   + dryMixStartingValue.ToString();
        wetMixTap1Text.text = "Wet Mix 1: " + wetMixStartingValue.ToString();
        wetMixTap2Text.text = "Wet Mix 2: " + wetMixStartingValue.ToString();
        wetMixTap3Text.text = "Wet Mix 3: " + wetMixStartingValue.ToString();
        delayText.text      = "Delay: "     + delayText.ToString();
        rateText.text       = "Rate: "      + rateText.ToString();
        depthText.text      = "Depth: "     + depthText.ToString();
        //feedbackText.text   = "Feedback: "  + feedbackText.ToString();

        dryMixSlider.value   = dryMixStartingValue / DRY_MIX_MAX;
        wetMix1Slider.value  = wetMixStartingValue / WET_MIX_MAX;
        wetMix2Slider.value  = wetMixStartingValue / WET_MIX_MAX;
        wetMix3Slider.value  = wetMixStartingValue / WET_MIX_MAX;
        delaySlider.value    = delayStartingValue / DELAY_MAX;
        rateSlider.value     = rateStartingValue / RATE_MAX;
        depthSlider.value    = depthStartingValue / DEPTH_MAX;
        //feedbackSlider.value = feedbackStartingValue / FEEDBACK_MAX;

        //Adds a listener to the main slider and invokes a method when the value changes.
        dryMixSlider.onValueChanged.AddListener(OnDryMixSliderValueChanged);
        wetMix1Slider.onValueChanged.AddListener(OnWetMix1SliderValueChanged);
        wetMix2Slider.onValueChanged.AddListener(OnWetMix2SliderValueChanged);
        wetMix3Slider.onValueChanged.AddListener(OnWetMix3SliderValueChanged);
        delaySlider.onValueChanged.AddListener(OnDelaySliderValueChanged);
        rateSlider.onValueChanged.AddListener(OnRateSliderValueChanged);
        depthSlider.onValueChanged.AddListener(OnDepthSliderValueChanged);
        //feedbackSlider.onValueChanged.AddListener(OnFeedbackSliderValueChanged);

    }

    protected void OnDryMixSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().dryMix = value * DRY_MIX_MAX;
            dryMixText.text = "Dry Mix: " + instrument.GetComponent<AudioChorusFilter>().dryMix.ToString();
        }
    }
    protected void OnWetMix1SliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().wetMix1 = value * WET_MIX_MAX;
            wetMixTap1Text.text = "Wet Mix 1: " + instrument.GetComponent<AudioChorusFilter>().wetMix1.ToString();
        }
    }

    protected void OnWetMix2SliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().wetMix2 = value * WET_MIX_MAX;
            wetMixTap2Text.text = "Wet Mix 2: " + instrument.GetComponent<AudioChorusFilter>().wetMix2.ToString();
        }
    }

    protected void OnWetMix3SliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().wetMix3 = value * WET_MIX_MAX;
            wetMixTap3Text.text = "Wet Mix 3: " + instrument.GetComponent<AudioChorusFilter>().wetMix3.ToString();
        }
    }

    protected void OnDelaySliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().delay = value * DELAY_MAX;
            delayText.text = "Delay: " + instrument.GetComponent<AudioChorusFilter>().delay.ToString();
        }
    }

    protected void OnRateSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().rate = value * RATE_MAX;
            rateText.text = "Rate: " + instrument.GetComponent<AudioChorusFilter>().rate.ToString();
        }
    }

    protected void OnDepthSliderValueChanged(float value)
    {
        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioChorusFilter>().depth = value * DEPTH_MAX;
            depthText.text = "Depth: " + instrument.GetComponent<AudioChorusFilter>().depth.ToString();
        }
    }

    //protected void OnFeedbackSliderValueChanged(float value)
    //{
    //    foreach (var instrument in instruments)
    //    {
    //        instrument.GetComponent<AudioChorusFilter>().feedback = value * FEEDBACK_MAX;
    //        feedbackText.text = "Feedback: " + instrument.GetComponent<AudioChorusFilter>().feedback.ToString();
    //    }
    //}
}
