using UnityEngine;

public class TileCollider : MonoBehaviour
{
    [SerializeField] private Tile _tile;
    [SerializeField] private Collider _collider;
    [SerializeField] private PhysicMaterial _slippery;

    private void OnCollisionEnter(Collision collision)
    {
        _tile.IsControlling = false;
        _tile.TileRB.useGravity = true;
    }

    public void BecomeSlippery() => _collider.material = _slippery;

    public void BecomeUnslippery() => _collider.material = null;
}
