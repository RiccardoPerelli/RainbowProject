using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliderInteraction : MonoBehaviour
{

    public List<GameObject> instruments;

    public void RemoveObjectFromList(GameObject gameObjectToRemove)
    {
        if (gameObjectToRemove.tag.Equals("Instrument"))
        {
            for (int i = 0; i <= instruments.Count; i++)
            {
                if (GameObject.ReferenceEquals(instruments[i], gameObjectToRemove))
                {
                    instruments.RemoveAt(i);
                }
            }
        }
    }

}
