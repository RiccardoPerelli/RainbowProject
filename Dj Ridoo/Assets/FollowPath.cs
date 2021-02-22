using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject posEnd;
    public float time;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("position", posEnd.transform, "easeType", iTween.EaseType.easeInOutSine, "time", time, "loopType", iTween.LoopType.loop));
    }
}
