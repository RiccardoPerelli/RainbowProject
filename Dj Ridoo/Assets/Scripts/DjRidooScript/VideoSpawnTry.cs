using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSpawnTry : MonoBehaviour
{

    public GameObject video;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(video, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
