using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]
    public float yOffset = 0;
    public float xOffset = 0;
    public float zOffset = 0;
    public float followVelocity = 0;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 velocity = (transform.position - playerTransform.position) / Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(playerTransform.position.x + xOffset, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset), Time.deltaTime * followVelocity);
        }
    }

}
