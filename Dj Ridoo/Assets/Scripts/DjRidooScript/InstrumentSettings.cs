using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSettings : MonoBehaviour
{

    //nome dello strumento
    [SerializeField]
    private string nameForInstrument;

    // Start is called before the first frame update
    void Start()
    {
        SaveLoadManager.Init();

    }

   

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            //passo nome filtro selezionato
            string filter = "high-pass";
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

       

        string[] player = song.instruments;

        for(int k=0; k<player.Length; k++)
        {
            Debug.Log(player[k]);
            InstrumentData ins = JsonUtility.FromJson<InstrumentData>(player[k]);
            Debug.Log(ins.name);
            if(ins.name == nameForInstrument)
            {
                Debug.Log(filter);
                
                ins.filter = filter;
                string updated = JsonUtility.ToJson(ins);
                player[k] = updated;

            }

        }

        //update savedData sul suo file senza crearne uno nuovo!
        for (int j=0; j<player.Length; j++)
        {
            Debug.Log(player[j]);
        }
        song.instruments = player;
        string updated_data = JsonUtility.ToJson(song);
        Debug.Log(updated_data);
        SaveLoadManager.UpdateSavings(updated_data);

        

        
    }

    private void Load()
    {
        string savedData = SaveLoadManager.Load();
        if(savedData != null)
        {
            Debug.Log(savedData);

            InstrumentData instrument = JsonUtility.FromJson<InstrumentData>(savedData);

            Debug.Log(instrument.name);
            Debug.Log(instrument.filter);

        }
    }
    

}
