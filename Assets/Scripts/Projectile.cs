using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public float spd;
    private float lifeTime = 10f;
    
    void Start()
    {
        StartCoroutine(SelfDestroy());
        transform.GetChild(0).transform.rotation = Quaternion.Euler(60,0,-90);
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward* spd;
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "wall")
        {
            //Destroy(this.gameObject);
        }
        else if(other.gameObject.GetComponent<PlayerMovement>())
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject, 0.5f);
        yield return 0;
    }
}
