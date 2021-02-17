using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonPression : ButtonPression
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerAction();
        }
    }
    protected override void TriggerAction()
    {
        SaveInstruments();
        SaveMixers();
    }

    private static void SaveMixers()
    {
        int first = 0;
        GameObject[] mixers = GameObject.FindGameObjectsWithTag("Mixer");
        foreach (GameObject mixer in mixers)
        {
            Debug.Log(mixer.name);
            first++;
            SavingManager.Instance.Save(mixer.name, mixer, first);
        }
    }

    private static void SaveInstruments()
    {
        int first_ins = 0;
        GameObject[] instruments = GameObject.FindGameObjectsWithTag("Instrument");
        foreach (GameObject instrument in instruments)
        {
            Debug.Log(instrument.name);
            first_ins++;
            SavingManager.Instance.SaveInstrument(instrument.name, instrument, first_ins);
        }
    }
}
