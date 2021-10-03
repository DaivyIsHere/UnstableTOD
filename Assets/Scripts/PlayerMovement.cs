using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _image;

    [SerializeField] private float spd;
    private Rigidbody rb;

    public bool slippery = false;
    public float maxDamageCD = 1.5f;
    public float _DamageCD = 0;


    void Awake()
    {
        if (instance == null)
            instance = this;
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {

    }

    void Update()
    {
        if (!CanTakeDamage())
        {
            _DamageCD -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (slippery)
        {
            SlipperyMovement();
        }
        else
        {
            StandardMovement();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (CanTakeDamage())
                TakeDamage();
        }
    }

    bool CanTakeDamage()
    {
        return _DamageCD <= 0;
    }

    public void TakeDamage()
    {
        _DamageCD = maxDamageCD;
        GameManager.instance.PlayerTakeDamage();
    }

    void StandardMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(x * spd, rb.velocity.y, z * spd);

        if (x < 0)
            _image.transform.localScale = new Vector3(-5, 5, 5);
        else if (x > 0)
            _image.transform.localScale = new Vector3(5, 5, 5);

        _animator.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(z));
    }

    void SlipperyMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //print(rb.velocity.magnitude);
        if (rb.velocity.magnitude < spd * 0.8f)
            rb.AddForce(new Vector3(x * spd, 0, z * spd));

        if (x < 0)
            _image.transform.localScale = new Vector3(-5, 5, 5);
        else if (x > 0)
            _image.transform.localScale = new Vector3(5, 5, 5);

        _animator.SetFloat("Speed", Mathf.Abs(x) + Mathf.Abs(z));
    }
}
