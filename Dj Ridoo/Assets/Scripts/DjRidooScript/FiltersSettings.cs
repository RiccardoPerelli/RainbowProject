using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiltersSettings : MonoBehaviour
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

     
    // Start is called before the first frame update
    void Start()
    {
        
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
            
            filters = GameObject.FindGameObjectsWithTag("Filter");
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


    public void Save(string filter, GameObject o, int first)
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
        position.Add(o.transform.position.x);
        position.Add(o.transform.position.y);
        position.Add(o.transform.position.z);

        rotation.Add(o.transform.rotation.x);
        rotation.Add(o.transform.rotation.y);
        rotation.Add(o.transform.rotation.z);

        Debug.Log(o.transform.rotation.x);
        Debug.Log(o.transform.rotation.y);
        Debug.Log(o.transform.rotation.z);
        fd.position = position;
        fd.rotation = rotation;

        List<int> player = new List<int>();
        List<GameObject> instruments = new List<GameObject>();

        if (filter.Contains("LowPassMixer"))
        {
            instruments = o.GetComponent<LowPassSliderInteraction>().instruments;

        }
        if (filter.Contains("HighPassMixer"))
        {
            instruments = o.GetComponent<HighPassSliderInteraction>().instruments;

        }
        if (filter.Contains("ChorusMixer"))
        {
            instruments = o.GetComponent<ChorusSliderInteraction>().instruments;

        }
        if (filter.Contains("EchoMixer"))
        {
            instruments = o.GetComponent<EchoSliderInteraction>().instruments;

        }
        if (filter.Contains("DistorsionMixer"))
        {
            instruments = o.GetComponent<DistorsionSliderInteraction>().instruments;

        }





        foreach (GameObject instrument in instruments)
        {
            
            player.Add(instrument.GetInstanceID());
        }

        


        //fd.instruments = player;

        //caso d'esempio poi cancellalo
        //GameObject cg = GameObject.FindGameObjectWithTag("Instrument");
        //InstrumentData ins_cg = new InstrumentData();
        //ins_cg.name = cg.name;


        //List<float> cg_position = new List<float>();
        //List<float> cg_rotation = new List<float>();

        //cg_position.Add(cg.transform.position.x);
        //cg_position.Add(cg.transform.position.y);
        //cg_position.Add(cg.transform.position.z);
        //cg_rotation.Add(cg.transform.rotation.eulerAngles.x);
        //cg_rotation.Add(cg.transform.rotation.eulerAngles.y);
        //cg_rotation.Add(cg.transform.rotation.eulerAngles.z);



        //ins_cg.position = cg_position;
        //ins_cg.rotation = cg_rotation;

        //string updated_cg = JsonUtility.ToJson(ins_cg);
        //player.Add(updated_cg);

        fd.instruments = player;

        if (filter.Contains("LowPassMixer"))
        {
            LowPass lp = new LowPass();
            lp.cutoff_freq = o.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            lp.resonance = o.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            par = JsonUtility.ToJson(lp);
            
        }
        if (filter.Contains("ChorusMixer"))
        {
            Chorus ch = new Chorus();
            ch.dry_mix = chorus.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            ch.wet_mix_tap_1 = chorus.transform.GetChild(0).Find("WetMixTap1Slider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.wet_mix_tap_2 = chorus.transform.GetChild(0).Find("WetMixTap2Slider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.wet_mix_tap_3 = chorus.transform.GetChild(0).Find("WetMixTap3Slider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.delay = chorus.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.depth = chorus.transform.GetChild(0).Find("DepthSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            ch.rate = chorus.transform.GetChild(0).Find("RateSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            par = JsonUtility.ToJson(ch);
        }
        if (filter.Contains("DistorsionMixer"))
        {
            Distortion d = new Distortion();
            d.level= o.transform.Find("DistorsionSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            par = JsonUtility.ToJson(d);
        }
        if (filter.Contains("HighPassMixer"))
        {
            HighPass hp = new HighPass();
            
            hp.cutoff_freq = o.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            hp.resonance = o.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            par = JsonUtility.ToJson(hp);
        }
        if (filter.Contains("EchoMixer"))
        {
            Echo eco = new Echo();

            eco.dry_mix = o.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            eco.wet_mix = o.transform.GetChild(0).Find("WetMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue;

            eco.delay= o.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue;
            
            eco.decay =  o.transform.GetChild(0).Find("DecaySlider").gameObject.GetComponent<SliderPosition>().sliderValue;

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

   

    private void Load()
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

                switch (player.name)
                {
                    case "ElectricGuitar":
                        Instantiate(eletricGuitar, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);

                        break;
                    case "ClassicGuitar":

                        Instantiate(classicGuitar, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);
                        break;
                    case "Drums":

                        Instantiate(drums, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);

                        break;
                    case "Tastiera":

                        Instantiate(tastiera, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);

                        break;
                    case "Microfone":

                        Instantiate(microfone, new Vector3(player.position[0], player.position[1], player.position[2]), new Quaternion(player.rotation[0], player.rotation[1], player.rotation[2], 1), connectingCables.transform);

                        break;
                }


            }

            List<string> filters = song.filters;

            foreach (string filter in filters)
            {
                

                FiltersData fd = JsonUtility.FromJson<FiltersData>(filter);
                Debug.Log(fd.name);

               
                if (fd.name.Contains("LowPassMixer"))
                {
                    Instantiate(lowpass, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach(string p in fd.parameters)
                    {
                        LowPass lp = JsonUtility.FromJson<LowPass>(p);
                        float cutofffreq = lp.cutoff_freq;
                        Debug.Log(cutofffreq);
                        float resonance = lp.resonance;
                        lowpass.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue = cutofffreq;
                        /*lowpass.transform.Find("FrequencySlider").position = new Vector3(lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().startingXPosition,
                            cutofffreq, lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().startingZPosition);*/
                        lowpass.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue = resonance;

                       
                        
                        
                    }

                    


                    foreach (int id in fd.instruments)

                    {

                        
                        connectFilterInstrument(id, lowpass);



                    }




                }
                if (fd.name.Contains("HighPassMixer"))
                {
                    Instantiate(highpass, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        HighPass hp = JsonUtility.FromJson<HighPass>(p);
                        float cutofffreq = hp.cutoff_freq;
                        Debug.Log(cutofffreq);
                        float resonance = hp.resonance;
                        highpass.transform.GetChild(0).Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().sliderValue = cutofffreq;
                        highpass.transform.GetChild(0).Find("ResonanceSlider").gameObject.GetComponent<SliderPosition>().sliderValue = resonance;
                        
                    }

                    foreach (int id in fd.instruments)

                    {


                        connectFilterInstrument(id, lowpass);



                    }


                }
                if (fd.name.Contains("ChorusMixer"))
                {
                    Debug.Log("chorus");
                    Debug.Log(RestoreAngles(fd.rotation[0]));
                    Debug.Log(RestoreAngles(fd.rotation[1]));
                    Debug.Log(RestoreAngles(fd.rotation[2]));
                    Instantiate(chorus, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
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

                        chorus.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue = dry_mix ;
                        
                        chorus.transform.GetChild(0).Find("WetMixTap1Slider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix_tap_1;
                        chorus.transform.GetChild(0).Find("WetMixTap2Slider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix_tap_2;
                        chorus.transform.GetChild(0).Find("WetMixTap3Slider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix_tap_3;
                        chorus.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue = delay;
                        chorus.transform.GetChild(0).Find("DepthSlider").gameObject.GetComponent<SliderPosition>().sliderValue = depth;
                        chorus.transform.GetChild(0).Find("RateSlider").gameObject.GetComponent<SliderPosition>().sliderValue = rate;

                        
                    }


                    foreach (int id in fd.instruments)

                    {


                        connectFilterInstrument(id, lowpass);



                    }
                }
                if (fd.name.Contains("EchoMixer"))
                {
                    Instantiate(echo, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        Echo eco = JsonUtility.FromJson<Echo>(p);
                        float decay = eco.decay;
                        float delay = eco.delay;
                        float dry_mix = eco.dry_mix;
                        float wet_mix = eco.wet_mix;
                        
                        echo.transform.GetChild(0).Find("DryMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue = dry_mix;

                        echo.transform.GetChild(0).Find("WetMixSlider").gameObject.GetComponent<SliderPosition>().sliderValue = wet_mix;
                       
                        echo.transform.GetChild(0).Find("DelaySlider").gameObject.GetComponent<SliderPosition>().sliderValue = delay;
                        echo.transform.GetChild(0).Find("DecaySlider").gameObject.GetComponent<SliderPosition>().sliderValue = decay;

                        
                    }


                    foreach (int id in fd.instruments)

                    {


                        connectFilterInstrument(id, lowpass);



                    }

                }
                if (fd.name.Contains("DistorsionMixer"))
                {
                    Instantiate(distortion, new Vector3(fd.position[0], fd.position[1], fd.position[2]), new Quaternion(fd.rotation[0], fd.rotation[1], fd.rotation[2], 1));
                    foreach (string p in fd.parameters)
                    {
                        Distortion d = JsonUtility.FromJson<Distortion>(p);
                        float level = d.level;
                        Debug.Log(level);
                        distortion.transform.GetChild(0).Find("DistorsionSlider").gameObject.GetComponent<SliderPosition>().sliderValue = level;

                        
                    }


                    foreach (int id in fd.instruments)

                    {


                        connectFilterInstrument(id, lowpass);



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
        
        GameObject o = findInstrumentById(id);
        connectingCables.GetComponent<ConnectingCables>().SpawnLinking(o, filter);

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
