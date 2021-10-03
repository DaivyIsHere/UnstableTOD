using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private TileCollider[] _colliders = new TileCollider[4];

    [Header("Parameters")]
    [SerializeField] private float _dropSpeed = 0.5f;
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private float _boundary = 3f;

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

    private void Dropping()
    {
        var y = -_dropSpeed * Time.deltaTime;
        transform.Translate(new Vector3(0, y, 0), Space.World);
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
