using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private float _movement = 0.5f;
    [SerializeField] private float _boundary = 3f;

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
            CheckBoundary();
            CheckInput();
        }
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
            var x = _crossLeft ? 0f : -_movement;
            transform.Translate(new Vector3(x, 0, 0), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            var x = _crossRight ? 0f : _movement;
            transform.Translate(new Vector3(x, 0, 0), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
        }
    }
}
