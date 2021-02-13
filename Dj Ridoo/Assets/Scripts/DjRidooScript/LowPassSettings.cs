using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPassSettings : FilterSliderInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            //passo nome filtro selezionato
            FiltersData.Save(0.08f, 0.2f);
            //Save(100, 10);

        }

        if (Input.GetKeyDown(KeyCode.B))
        {

            Load();
        }

    }

    public void Save(float cutofffreq, float resonance)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);


        List<string> filters = song.filters;

       for(int j = 0; j< filters.Count; j++)
        
        {
            
            FiltersData fil = JsonUtility.FromJson<FiltersData>(filters[j]);
          
            if (fil.name == "Lowpass")
            {
                LowPass lp = new LowPass();
                lp.cutoff_freq = cutofffreq;
                lp.resonance = resonance;
                string par = JsonUtility.ToJson(lp);
                Debug.Log(par);
                fil.parameters.Add(par);
                string fd = JsonUtility.ToJson(fil);
                filters[j] = fd;
            }

           
        }





        //update savedData sul suo file senza crearne uno nuovo!

        song.filters = filters;
        string updated_data = JsonUtility.ToJson(song);

        Debug.Log(updated_data);
        SaveLoadManager.UpdateSavings(updated_data);

        //for (int k = 0; k < filters.Length; k++)
        //{
        //    GameObject filter = GetComponent<GameObject>();

        //    LowPass lp = JsonUtility.FromJson<LowPass>(filters[k]);
        //    Debug.Log(filter.name);
        //    if (lp.name == filter.name)
        //    {


        //        string updated = JsonUtility.ToJson(filter);
        //        filters[k] = updated;

        //    }

        //}

        ////update savedData sul suo file senza crearne uno nuovo!
        //for (int j = 0; j < filters.Length; j++)
        //{
        //    Debug.Log(filters[j]);
        //}
        //song.filters = filters;
        //string updated_data = JsonUtility.ToJson(song);
        //Debug.Log(updated_data);
        //SaveLoadManager.UpdateSavings(updated_data);




    }



    private void Load()
    {
        string savedData = SaveLoadManager.Load();
        if (savedData != null)
        {
            Debug.Log(savedData);

            InstrumentData instrument = JsonUtility.FromJson<InstrumentData>(savedData);

            Debug.Log(instrument.name);
            Debug.Log(instrument.filter);

        }
    }
}
