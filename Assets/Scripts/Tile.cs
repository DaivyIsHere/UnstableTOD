using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private TileCollider[] _colliders = new TileCollider[4];

    [Header("Parameters")]
    [SerializeField] private float _dropSpeed = 1f;
    [SerializeField] private float _moveSpeed = 0.25f;
    [SerializeField] private float _boundary = 2f;

    [Space]
    public Rigidbody TileRB;
    public TileType tileType;
    public CardType cardType;
    public bool IsControlling;

    private bool _crossLeft;
    private bool _crossRight;

    void Update()
    {
        if (IsControlling)
        {
            //drop
            //Q E to rotate
            Dropping();
            CheckBoundary();
            CheckInput();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (IsControlling)
        {
            if (other.transform.GetComponent<Tile>())
            {
                if (!other.transform.GetComponent<Tile>().IsControlling)
                {
                    IsControlling = false;
                    GetComponent<Rigidbody>().useGravity = true;
                }
            }
            else if (other.gameObject.tag == "Ground")
            {
                IsControlling = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void Dropping()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, -_dropSpeed, 0);
        //var y = -_dropSpeed * Time.deltaTime;
        //transform.Translate(new Vector3(0, y, 0), Space.World);
    }

    private void CheckBoundary()
    {
        if (transform.localPosition.x <= -_boundary)
        {
            _crossLeft = true;
        }
        else if (transform.localPosition.x >= _boundary)
        {
            _crossRight = true;
        }
        else
        {
            _crossLeft = false;
            _crossRight = false;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var x = _crossLeft ? 0f : -_moveSpeed;
            transform.Translate(new Vector3(x, 0, 0), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            var x = _crossRight ? 0f : _moveSpeed;
            transform.Translate(new Vector3(x, 0, 0), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
        }
    }

    public void CollidersUnslippery()
    {
        foreach (var collider in _colliders)
            collider.BecomeUnslippery();
    }
}
