using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float spd;
    
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.up* spd;
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
