using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveLoadManager
{

    public static readonly string SAVE_FOLDER = Application.dataPath + "/Savings/";

    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Create save folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        int saveNumber = 1;
        while(File.Exists(SAVE_FOLDER + "save_" + saveNumber +".txt"))
        {
            saveNumber++;
        }
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".txt", saveString);
    }

    public static string Load()
    {

        DirectoryInfo directory = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directory.GetFiles("*.txt");
        FileInfo mostRecentFile = null;
        foreach(FileInfo file in saveFiles)
        {
            if(mostRecentFile == null)
            {
                mostRecentFile = file;
            }else
            {
                if(file.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = file;
                }
            }
        }

        if(mostRecentFile != null)
        {
            Debug.Log(mostRecentFile.FullName);
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;


        }
        else
        {
            return null;
        }
            
    }

    public static void UpdateSavings(string updated_data)
    {

        DirectoryInfo directory = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directory.GetFiles("*.txt");
        FileInfo mostRecentFile = null;
        foreach (FileInfo file in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = file;
            }
            else
            {
                if (file.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = file;
                }
            }
        }

        if (mostRecentFile != null)
        {
            Debug.Log(mostRecentFile.FullName);
            File.WriteAllText(mostRecentFile.FullName, updated_data);


        }
        

    }


}
