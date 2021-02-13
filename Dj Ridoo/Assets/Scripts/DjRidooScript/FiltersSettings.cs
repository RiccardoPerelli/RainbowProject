using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiltersSettings : MonoBehaviour
{
    public GameObject highpass;
    public GameObject lowpass;
    public GameObject chorus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            //passo nome filtro selezionato
            string filter = "Lowpass";
            Save(filter);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {

            //Load();
        }
    }


    public void Save(string filter)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);



        List<string> filters = song.filters;
        FiltersData fd = new FiltersData();
        fd.name = filter;


        string updated = JsonUtility.ToJson(fd);
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

            List<string> filters = song.filters;

            foreach (string filter in filters)
            {
                //prende il gameobject dello strumento, come si fa?
                //GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //InstrumentData player = JsonUtility.FromJson<InstrumentData>(ins);

                FiltersData fd = JsonUtility.FromJson<FiltersData>(filter);


                if (fd.name.Equals("Lowpass"))
                {
                    Instantiate(lowpass);
                    foreach(string p in fd.parameters)
                    {
                        LowPass lp = JsonUtility.FromJson<LowPass>(p);
                        float cutofffreq = lp.cutoff_freq;
                        float resonance = lp.resonance;
                        lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().thisYPosition = cutofffreq;
                        /*lowpass.transform.Find("FrequencySlider").position = new Vector3(lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().startingXPosition,
                            cutofffreq, lowpass.transform.Find("FrequencySlider").gameObject.GetComponent<SliderPosition>().startingZPosition);*/

                    }
                    
                }

                //associarli al gameobject, come si fa?
                //nameForInstrument = player.name;
                //idForInstrument = player.id;

            }

        }
    }


}
