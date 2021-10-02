using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float spd;
    private Rigidbody rb;

    public bool slippery = false;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(slippery)
        {
            SlipperyMovement();
        }
        else
        {
            StandardMovement();
        }
    }

    void StandardMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(x* spd, rb.velocity.y, z*spd);
    }

    void SlipperyMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //print(rb.velocity.magnitude);
        if(rb.velocity.magnitude < spd)
            rb.AddForce(new Vector3(x* spd, 0, z*spd));
    }
}
