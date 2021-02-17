using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProjectSettings : MonoBehaviour
{

    private static AudioProjectSettings _instance;
    public static AudioProjectSettings Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveLoadManager.Init();
        InitializeJson();
    }

    // Update is called once per frame
    void Update()
    {
        //seleziono song nella UI
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitializeJson();
        }
    }

    public void InitializeJson()
    {
        int id_project = 1;
        while (File.Exists(Path.Combine(Application.persistentDataPath + "/Savings/" + "save_" + id_project + ".txt")))
        {
            id_project++;
        }
        string song = "djridooProject_" + id_project;
        Save(song);
    }

    private void Save(string project_name )
    {
        AudioProject project = new AudioProject();
        //capire come prendere nome progetto: nome della canzone scelta?
        project.project_name = project_name;
        //project.instruments = instruments;
        List<string> filters = project.filters;
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
