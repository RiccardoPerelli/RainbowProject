using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliderInteraction : MonoBehaviour
{

    public List<GameObject> instruments;

    public void RemoveObjectFromList(GameObject gameObjectToRemove)
    {
        foreach (var instrument in instruments)
        {
            if (GameObject.ReferenceEquals(instrument, gameObjectToRemove))
            {
                instruments.Remove(gameObjectToRemove);
            }
        }
    }

}
