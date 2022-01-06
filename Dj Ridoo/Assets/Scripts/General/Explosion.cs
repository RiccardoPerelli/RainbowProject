using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float destroyTime;
    public GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Instrument" || collision.collider.gameObject.tag == "wall")
        {
            Destroy(this.gameObject, destroyTime);
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(expl, 3); // delete the explosion after 3 seconds
        }
    }
}
