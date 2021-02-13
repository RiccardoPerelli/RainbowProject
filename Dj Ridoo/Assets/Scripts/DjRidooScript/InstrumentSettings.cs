using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentSettings : MonoBehaviour
{

    //nome dello strumento
    [SerializeField]
    private string nameForInstrument;
    [SerializeField]
    private int idForInstrument= 1;

    // Start is called before the first frame update
    void Start()
    {
        SaveLoadManager.Init();

        //Load();
    }

   

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {

            //passo nome filtro selezionato
            string filter = "Lowpass";
            //Save(filter);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
           
            Load();
        }
        
        
        
    }

    //public void Save(string filter)
    //{
    //    string savedData = SaveLoadManager.Load();

    //    AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);

       

    //    List<string> player = song.instruments;

    //    for(int k=0; k<player.Length; k++)
    //    {
    //        Debug.Log(player[k]);
    //        InstrumentData ins = JsonUtility.FromJson<InstrumentData>(player[k]);
    //        Debug.Log(ins.name);
    //        if(ins.name == nameForInstrument)
    //        {
    //            Debug.Log(filter);
                
    //            ins.filter = filter;
    //            string updated = JsonUtility.ToJson(ins);
    //            player[k] = updated;

    //        }

    //    }

    //    //update savedData sul suo file senza crearne uno nuovo!
    //    for (int j=0; j<player.Length; j++)
    //    {
    //        Debug.Log(player[j]);
    //    }
    //    song.instruments = player;
    //    string updated_data = JsonUtility.ToJson(song);
    //    Debug.Log(updated_data);
    //    SaveLoadManager.UpdateSavings(updated_data);

        

        
    //}

    public void SaveInstrument(string instrument)
    {
        //salva strumento in lista quando se ne aggiunge uno nuovo alla scena
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);



        List<string> instruments = song.instruments;
        InstrumentData ins = new InstrumentData();
        ins.name = instrument;


        string updated = JsonUtility.ToJson(ins);
        instruments.Add(updated);



        //update savedData sul suo file senza crearne uno nuovo!

        song.instruments = instruments;
        string updated_data = JsonUtility.ToJson(song);

        Debug.Log(updated_data);
        SaveLoadManager.UpdateSavings(updated_data);


    }


    public void SaveInstrumentFilter(string filter)
    {
        //on collision between instruments e essenza filtro
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);



        List<string> filters = song.filters;
       

        foreach(string f in filters)
        {
            FiltersData fil = new FiltersData();

            if (fil.name == filter)
            {
                fil.instruments.Add(idForInstrument);
            }
        }
        

       


        //update savedData sul suo file senza crearne uno nuovo!

        song.filters = filters;
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
            
            AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);

            List<string> instruments = song.instruments;

            foreach(string ins in instruments)
            {
                //prende il gameobject dello strumento, come si fa?
                GameObject o = GameObject.CreatePrimitive(PrimitiveType.Cube);
                InstrumentData player = JsonUtility.FromJson<InstrumentData>(ins);
                //associarli al gameobject, come si fa?
                nameForInstrument = player.name;
                idForInstrument = player.id;

            }
           

        }
    }
    

}
