using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliderInteraction : MonoBehaviour
{

    public List<GameObject> instruments;

    private void Update()
    {
        Debug.Log("instrument lists size: " + instruments.Count);
    }

    public void RemoveObjectFromList(GameObject gameObjectToRemove)
    {
        for(int i = 0; i <= instruments.Count; i++)
        {
            if (GameObject.ReferenceEquals(instruments[i], gameObjectToRemove))
            {
                instruments.RemoveAt(i);
            }
        }
    }

}
