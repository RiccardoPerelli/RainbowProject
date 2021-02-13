using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiltersData
{
    public string name;
    public List<int> instruments;
    public List<string> parameters;

    public static void Save(float cutofffreq, float resonance)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);


        List<string> filters = song.filters;

        for (int j = 0; j < filters.Count; j++)

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


            if (fil.name == "Highpass")
            {
                HighPass lp = new HighPass();
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

        




    }

    public static void Save(float level)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);


        List<string> filters = song.filters;

        for (int j = 0; j < filters.Count; j++)

        {

            FiltersData fil = JsonUtility.FromJson<FiltersData>(filters[j]);

            if (fil.name == "Distortion")
            {
                Distortion lp = new Distortion();
                lp.level = level;
                
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






    }

    public static void Save(float dry_mix, float wet_mix_tap_1, float wet_mix_tap_2, float wet_mix_tap_3, float delay, float rate, float depth, float feedback)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);


        List<string> filters = song.filters;

        for (int j = 0; j < filters.Count; j++)

        {

            FiltersData fil = JsonUtility.FromJson<FiltersData>(filters[j]);

            if (fil.name == "Chorus")
            {
                Chorus lp = new Chorus();
                lp.dry_mix = dry_mix;
                lp.depth = depth;
                lp.delay = delay;
                lp.feedback = feedback;
                lp.rate = rate;
                lp.wet_mix_tap_1 = wet_mix_tap_1;
                lp.wet_mix_tap_2 = wet_mix_tap_2;
                lp.wet_mix_tap_3 = wet_mix_tap_3;

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






    }

    public static void Save(float delay, float decay, float max_channels, float dry_mix, float wet_mix)
    {
        string savedData = SaveLoadManager.Load();

        AudioProject song = JsonUtility.FromJson<AudioProject>(savedData);


        List<string> filters = song.filters;

        for (int j = 0; j < filters.Count; j++)

        {

            FiltersData fil = JsonUtility.FromJson<FiltersData>(filters[j]);

            if (fil.name == "Echo")
            {
                Echo lp = new Echo();
                lp.delay = delay;
                lp.decay = decay ;
                lp.dry_mix = dry_mix;
                lp.max_channels = max_channels;
                lp.wet_mix = wet_mix;

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






    }



}

public class Chorus
{
    
    public float dry_mix;
    public float wet_mix_tap_1;
    public float wet_mix_tap_2;
    public float wet_mix_tap_3;
    public float delay;
    public float rate;
    public float depth;
    public float feedback;
}

public class LowPass
{
   
    public float cutoff_freq;
    public float resonance;
}

public class HighPass
{
    
    public float cutoff_freq;
    public float resonance;
}

public class Distortion
{
    
    public float level;
    
}

public class Echo
{
   
    public float delay;
    public float decay;
    public float max_channels;
    public float dry_mix;
    public float wet_mix;
}
