using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public GameObject highpass;
    public GameObject lowpass;
    public GameObject chorus;
    public GameObject echo;
    public GameObject distortion;
    public GameObject[] filters;

    public GameObject eletricGuitar;
    public GameObject drums;
    public GameObject classicGuitar;
    public GameObject microfone;
    public GameObject tastiera;

    public GameObject connectingCables;

    public GameObject[] instruments;

    private static SavingManager _instance;
    public static SavingManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            int first_ins = 0;

            instruments = GameObject.FindGameObjectsWithTag("Instrument");
            foreach (GameObject o in instruments)
            {
                Debug.Log(o.name);
                first_ins++;
                SaveInstrument(o.name, o, first_ins);
            }
            int first = 0;
            
            filters = GameObject.FindGameObjectsWithTag("Mixer");
            foreach(GameObject o in filters)
            {
                Debug.Log(o.name);
                first++;
                Save(o.name, o, first);             
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void SaveInstrument(string instrument, GameObject o, int first)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);

        List<string> instruments;

        if (first == 1)
        {
            instruments = new List<string>();
        }
        else
        {
            instruments = song.instruments;

        }

        InstrumentData ins = new InstrumentData();
        ins.name = instrument;

        ins.id = o.GetInstanceID();

        List<float> position = new List<float>();
        List<float> rotation = new List<float>();
        
        position.Add(o.transform.position.x);
        position.Add(o.transform.position.y);
        position.Add(o.transform.position.z);

        rotation.Add(o.transform.rotation.x);
        rotation.Add(o.transform.rotation.y);
        rotation.Add(o.transform.rotation.z);

        Debug.Log(o.transform.rotation.x);
        Debug.Log(o.transform.rotation.y);
        Debug.Log(o.transform.rotation.z);
        ins.position = position;
        ins.rotation = rotation;

        string updated = JsonUtility.ToJson(ins);
        instruments.Add(updated);

        //update savedData sul suo file senza crearne uno nuovo!
        song.instruments = instruments;
        string updated_data = JsonUtility.ToJson(song);

        Debug.Log(updated_data);
        SaveLoadManager.UpdateSavings(updated_data);

    }


    public void Save(string filter, GameObject filterReference, int first)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);
        List<string> filters;

        if (first == 1)
        {
           filters = new List<string>();
        }
        else
        {
            filters = song.filters;
        }
        
        FiltersData fd = new FiltersData();
        fd.name = filter;
        List<string> parameters = new List<string>();

        List<float> position = new List<float>();
        List<float> rotation = new List<float>();
        string par = "";
        position.Add(filterReference.transform.position.x);
        position.Add(filterReference.transform.position.y);
        position.Add(filterReference.transform.position.z);

        rotation.Add(filterReference.transform.rotation.eulerAngles.x);
        rotation.Add(filterReference.transform.rotation.eulerAngles.y);
        rotation.Add(filterReference.transform.rotation.eulerAngles.z);
        //rotation.Add(filterReference.transform.rotation.eulerAngles.w);

        Debug.Log(filterReference.transform.rotation.x);
        Debug.Log(filterReference.transform.rotation.y);
        Debug.Log(filterReference.transform.rotation.z);
        fd.position = position;
        fd.rotation = rotation;

        List<int> player = new List<int>();
        List<GameObject> instruments = new List<GameObject>();

        if (filter.Contains("LowPassMixer"))
        {
            instruments = filterReference.transform.GetChild(0).gameObject.GetComponent<LowPassSliderInteraction>().instruments;

        }
        if (filter.Contains("HighPassMixer"))
        {
            instruments = filterReference.transform.GetChild(0).gameObject.GetComponent<HighPassSliderInteraction>().instruments;

        }
        if (filter.Contains("ChorusMixer"))
        {
            instruments = filterReference.transform.GetChild(0).gameObject.GetComponent<ChorusSliderInteraction>().instruments;

        }
        if (filter.Contains("EchoMixer"))
        {
            instruments = filterReference.transform.GetChild(0).gameObject.GetComponent<EchoSliderInteraction>().instruments;

        }
        if (filter.Contains("DistorsionMixer"))
        {
            instruments = filterReference.transform.GetChild(0).gameObject.GetComponent<DistorsionSliderInteraction>().instruments;
        }

        foreach (GameObject instrument in instruments)
        {
            player.Add(instrument.GetInstanceID());
        }
        fd.instruments = player;

        if (filter.Contains("LowPassMixer"))
        {
            LowPass lp = new LowPass();
            lp.cutoff_freq = filterReference.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            lp.resonance = filterReference.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            par = JsonUtility.ToJson(lp);    
        }
        if (filter.Contains("ChorusMixer"))
        {
            Chorus ch = new Chorus();
            ch.dry_mix = filterReference.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            ch.wet_mix_tap_1 = filterReference.transform.GetChild(0).Find("WetMixTap1Slider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.wet_mix_tap_2 = filterReference.transform.GetChild(0).Find("WetMixTap2Slider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.wet_mix_tap_3 = filterReference.transform.GetChild(0).Find("WetMixTap3Slider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.delay = filterReference.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.depth = filterReference.transform.GetChild(0).Find("DepthSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.rate = filterReference.transform.GetChild(0).Find("RateSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            par = JsonUtility.ToJson(ch);
        }
        if (filter.Contains("DistorsionMixer"))
        {
            Distortion d = new Distortion();
            d.level = filterReference.transform.GetChild(0).Find("DistorsionSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            par = JsonUtility.ToJson(d);
        }
        if (filter.Contains("HighPassMixer"))
        {
            HighPass hp = new HighPass();
            
            hp.cutoff_freq = filterReference.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            hp.resonance = filterReference.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            par = JsonUtility.ToJson(hp);
        }
        if (filter.Contains("EchoMixer"))
        {
            Echo eco = new Echo();

            eco.dry_mix = filterReference.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            eco.wet_mix = filterReference.transform.GetChild(0).Find("WetMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            eco.delay = filterReference.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            eco.decay = filterReference.transform.GetChild(0).Find("DecaySlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            par = JsonUtility.ToJson(eco);
        }

        Debug.Log(par);

        parameters.Add(par);
        fd.parameters = parameters;
        Debug.Log("fine inserimento parametri");
        Debug.Log("prima inserimento lista filtri");

        string updated = JsonUtility.ToJson(fd);
        Debug.Log(updated);
        filters.Add(updated);
        //update savedData sul suo file senza crearne uno nuovo!
      
        song.filters = filters;
        string updated_data = JsonUtility.ToJson(song);
        
        Debug.Log(updated_data);
        SaveLoadManager.UpdateSavings(updated_data);
    }

    public void Load()
    {
        string savedData = SaveLoadManager.Load();
        if (savedData != null)
        {
            Debug.Log(savedData);

            AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);

            List<string> instruments = song.instruments;

            foreach (string ins in instruments)
            {
                InstrumentData player = JsonUtility.FromJson<InstrumentData>(ins);

                if (player.name.Contains("ElectricGuitar"))
                {
                    GameObject o = Instantiate(eletricGuitar, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);
                    o.GetComponent<IdChecker>().id = player.id;
                }
                else if (player.name.Contains("ClassicGuitar"))
                {
                    GameObject o1 = Instantiate(classicGuitar, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);
                    o1.GetComponent<IdChecker>().id = player.id;
                }
                else if (player.name.Contains("Drums"))
                {
                    GameObject o2 = Instantiate(drums, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);
                    o2.GetComponent<IdChecker>().id = player.id;
                }
                else if (player.name.Contains("Tastiera"))
                {
                    GameObject o3 = Instantiate(tastiera, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);
                    o3.GetComponent<IdChecker>().id = player.id;
                }
                else if (player.name.Contains("Microfone"))
                {
                    GameObject o4 = Instantiate(microfone, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);
                    o4.GetComponent<IdChecker>().id = player.id;
                }
            }

            List<string> filters = song.filters;

            foreach (string filter in filters)
            {
                
                FiltersData fd = JsonUtility.FromJson<FiltersData>(filter);
                Debug.Log(fd.name);
  
                if (fd.name.Contains("LowPassMixer"))
                {
                    GameObject lowPassSpawned = Instantiate(lowpass, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach(string p in fd.parameters)
                    {
                        LowPass lp = JsonUtility.FromJson<LowPass>(p);
                        float cutofffreq = lp.cutoff_freq;
                        Debug.Log(cutofffreq);
                        float resonance = lp.resonance;
                        lowPassSpawned.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue = cutofffreq;
                        /*lowpass.transform.Find("FrequencySlider").position = new Vector3(lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().startingXPosition,
                            cutofffreq, lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().startingZPosition);*/
                        lowPassSpawned.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue = resonance;   
                    }

                    foreach (int id in fd.instruments)
                    {
                        connectFilterInstrument(id, lowPassSpawned.transform.GetChild(0).gameObject);
                    }
                }
                if (fd.name.Contains("HighPassMixer"))
                {
                    GameObject highPassSpawned = Instantiate(highpass, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        HighPass hp = JsonUtility.FromJson<HighPass>(p);
                        float cutofffreq = hp.cutoff_freq;
                        Debug.Log(cutofffreq);
                        float resonance = hp.resonance;
                        highPassSpawned.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue = cutofffreq;
                        highPassSpawned.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue = resonance;   
                    }

                    foreach (int id in fd.instruments)
                    {
                        connectFilterInstrument(id, highPassSpawned.transform.GetChild(0).gameObject);
                    }
                }
                if (fd.name.Contains("ChorusMixer"))
                {
                    Debug.Log("chorus");
                    Debug.Log(RestoreAngles(fd.rotation[0]));
                    Debug.Log(RestoreAngles(fd.rotation[1]));
                    Debug.Log(RestoreAngles(fd.rotation[2]));
                    GameObject chorusSpawned = Instantiate(chorus, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        Debug.Log(p);
                        Chorus ch = JsonUtility.FromJson<Chorus>(p);
                        float delay = ch.delay;
                        float depth = ch.depth;
                        float dry_mix = ch.dry_mix;
                        float rate = ch.rate;
                        float wet_mix_tap_1 = ch.wet_mix_tap_1;
                        float wet_mix_tap_2 = ch.wet_mix_tap_2;
                        float wet_mix_tap_3 = ch.wet_mix_tap_3;

                        chorusSpawned.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue = dry_mix ;

                        chorusSpawned.transform.GetChild(0).Find("WetMixTap1Slider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix_tap_1;
                        chorusSpawned.transform.GetChild(0).Find("WetMixTap2Slider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix_tap_2;
                        chorusSpawned.transform.GetChild(0).Find("WetMixTap3Slider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix_tap_3;
                        chorusSpawned.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue = delay;
                        chorusSpawned.transform.GetChild(0).Find("DepthSlider").gameObject.GetComponent<SliderPosition>().sliderValue = depth;
                        chorusSpawned.transform.GetChild(0).Find("RateSlider").gameObject.GetComponent<SliderPosition>().sliderValue = rate; 
                    }

                    foreach (int id in fd.instruments)
                    {
                        connectFilterInstrument(id, chorusSpawned.transform.GetChild(0).gameObject);
                    }
                }
                if (fd.name.Contains("EchoMixer"))
                {
                    GameObject echoSpawned = Instantiate(echo, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        Echo eco = JsonUtility.FromJson<Echo>(p);
                        float decay = eco.decay;
                        float delay = eco.delay;
                        float dry_mix = eco.dry_mix;
                        float wet_mix = eco.wet_mix;

                        echoSpawned.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue = dry_mix;
                        echoSpawned.transform.GetChild(0).Find("WetMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix;
                        echoSpawned.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue = delay;
                        echoSpawned.transform.GetChild(0).Find("DecaySlider").gameObject.GetComponent<SliderPosition>().sliderValue = decay;  
                    }
                    
                    foreach (int id in fd.instruments)
                    {
                        connectFilterInstrument(id, echoSpawned.transform.GetChild(0).gameObject);
                    }
                }
                if (fd.name.Contains("DistorsionMixer"))
                {
                    GameObject distorsionSpawned = Instantiate(distortion, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        Distortion d = JsonUtility.FromJson<Distortion>(p);
                        float level = d.level;
                        distorsionSpawned.transform.GetChild(0).Find("DistorsionSlider").gameObject.GetComponent<SliderPosition>().sliderValue = level;
                    }

                    foreach (int id in fd.instruments)
                    {
                        connectFilterInstrument(id, distorsionSpawned.transform.GetChild(0).gameObject);
                    }
                }
            }
        }
    }

    public float ConvertAngles(float angle)
    {
        if (angle < 180)
            return angle;
        angle = angle - 360;
        return angle;
    } 

    public float RestoreAngles(float angle)
    {
        if (angle > 0)
            return angle;
        angle = angle + 360;
        return angle;
    }

    public void connectFilterInstrument(int id, GameObject filter)
    {   
        GameObject instrument = findInstrumentById(id);
        connectingCables.GetComponent<ConnectingCables>().SpawnLinking(instrument, filter);
        if(filter.GetComponent<DistorsionSliderInteraction>() != null)
        {
            filter.GetComponent<DistorsionSliderInteraction>().instruments.Add(instrument);
            instrument.AddComponent(typeof(AudioDistortionFilter));
            instrument.GetComponent<AudioDistortionFilter>().distortionLevel = filter.GetComponent<DistorsionSliderInteraction>().distorsionLevelStartingValue;
        } 
        else if (filter.GetComponent<EchoSliderInteraction>() != null)
        {
            filter.GetComponent<EchoSliderInteraction>().instruments.Add(instrument);
            instrument.AddComponent(typeof(AudioEchoFilter));
            instrument.GetComponent<AudioEchoFilter>().delay = filter.GetComponent<EchoSliderInteraction>().delayLevelStartingValue;
            instrument.GetComponent<AudioEchoFilter>().decayRatio = filter.GetComponent<EchoSliderInteraction>().decayRationStartingValue;
            instrument.GetComponent<AudioEchoFilter>().wetMix = filter.GetComponent<EchoSliderInteraction>().wetMixStartingValue;
            instrument.GetComponent<AudioEchoFilter>().dryMix = filter.GetComponent<EchoSliderInteraction>().dryMixStartingValue;
        }
        else if (filter.GetComponent<LowPassSliderInteraction>() != null)
        {
            filter.GetComponent<LowPassSliderInteraction>().instruments.Add(instrument);
            instrument.AddComponent(typeof(AudioLowPassFilter));
            instrument.GetComponent<AudioLowPassFilter>().lowpassResonanceQ = filter.GetComponent<LowPassSliderInteraction>().resonanceStartingValue;
            instrument.GetComponent<AudioLowPassFilter>().cutoffFrequency = filter.GetComponent<LowPassSliderInteraction>().cutOffFrequencyStartingValue;
        }
        else if (filter.GetComponent<HighPassSliderInteraction>() != null)
        {
            filter.GetComponent<HighPassSliderInteraction>().instruments.Add(instrument);
            instrument.AddComponent(typeof(AudioHighPassFilter));
            instrument.GetComponent<AudioHighPassFilter>().highpassResonanceQ = filter.GetComponent<HighPassSliderInteraction>().resonanceStartingValue;
            instrument.GetComponent<AudioHighPassFilter>().cutoffFrequency = filter.GetComponent<HighPassSliderInteraction>().cutOffFrequencyStartingValue;
        }
        else if (filter.GetComponent<ChorusSliderInteraction>() != null)
        {
            filter.GetComponent<ChorusSliderInteraction>().instruments.Add(instrument);
            instrument.AddComponent(typeof(AudioChorusFilter));
            instrument.GetComponent<AudioChorusFilter>().dryMix = filter.GetComponent<ChorusSliderInteraction>().dryMixStartingValue;
            instrument.GetComponent<AudioChorusFilter>().wetMix1 = filter.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            instrument.GetComponent<AudioChorusFilter>().wetMix2 = filter.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            instrument.GetComponent<AudioChorusFilter>().wetMix3 = filter.GetComponent<ChorusSliderInteraction>().wetMixStartingValue;
            instrument.GetComponent<AudioChorusFilter>().delay = filter.GetComponent<ChorusSliderInteraction>().delayStartingValue;
            instrument.GetComponent<AudioChorusFilter>().rate = filter.GetComponent<ChorusSliderInteraction>().rateStartingValue;
            instrument.GetComponent<AudioChorusFilter>().depth = filter.GetComponent<ChorusSliderInteraction>().depthStartingValue;
        }
    }

    public GameObject findInstrumentById(int instrumentId) 
    {
        foreach (Transform child in connectingCables.transform)
        {
            if (child.gameObject.GetComponent<IdChecker>() != null)
            {
                if (child.gameObject.GetComponent<IdChecker>().id == instrumentId)
                {
                    return child.gameObject;
                }
            }
        }
       return null;
    }
}
