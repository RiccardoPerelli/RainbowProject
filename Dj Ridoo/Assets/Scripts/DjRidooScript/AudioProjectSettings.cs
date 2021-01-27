using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProjectSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveLoadManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //seleziono song nella UI
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string song = ""; // questa stringa in realtà è il risultato della selezione della song nella UI
            string dir_track_path = Application.dataPath + "/Resources/AudioClips/" + song + "/";
            DirectoryInfo dir = new DirectoryInfo(dir_track_path);
            int n_track = dir.GetFiles("*.mp3").Length;
            Debug.Log(n_track);
            string[] instruments = new string[n_track];
            int i = 0;
            foreach(FileInfo f in dir.GetFiles())
            {
                if (f.Name.Contains(".mp3.meta")){

                }
                else
                {
                    
                    InstrumentData player = new InstrumentData();

                    player.name = f.Name;
                    player.filter = "";

                    string json = JsonUtility.ToJson(player);
                    instruments[i] = json;
                    i++;
                }
                

               
            }

            
            //song è il project_name, instruments sono gli strumenti associati a quella song
            Save(song, instruments);
        }
        
    }

    private void Save(string project_name, string [] instruments )
    {
        
        AudioProject project = new AudioProject();
        //capire come prendere nome progetto: nome della canzone scelta?
        project.project_name = project_name;
        project.instruments = instruments;

        

        string json = JsonUtility.ToJson(project);
        Debug.Log(json);
        SaveLoadManager.Save(json);
    }

    private void Load()
    {
        string savedData = SaveLoadManager.Load();
        if (savedData != null)
        {
            Debug.Log(savedData);

            AudioProject project = JsonUtility.FromJson<AudioProject>(savedData);

            

        }
    }

    
}
