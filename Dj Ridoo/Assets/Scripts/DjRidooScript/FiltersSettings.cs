using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiltersSettings : MonoBehaviour
{
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

            Load();
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

            InstrumentData instrument = JsonUtility.FromJson<InstrumentData>(savedData);

            Debug.Log(instrument.name);
            Debug.Log(instrument.filter);

        }
    }


}
