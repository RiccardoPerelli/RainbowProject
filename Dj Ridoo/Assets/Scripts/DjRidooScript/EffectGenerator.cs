using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour
{

    [SerializeField] float destroyTime;
    public GameObject lowPassFilterUI;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Instrument")
        {
            GameObject lwp = Instantiate(lowPassFilterUI, collision.collider.gameObject.transform.position + offset, Quaternion.identity) as GameObject;
            //Destroy(expl, 3); // delete the explosion after 3 seconds 
            lwp.GetComponent<SliderInteraction>().instruments.Add(collision.collider.gameObject);
            Destroy(this.gameObject, destroyTime);
        }
    }
}
