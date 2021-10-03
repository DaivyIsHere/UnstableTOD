using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsecurityManager : MonoBehaviour
{
    public static InsecurityManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [Header("Storm")]
    [SerializeField] private float _windIntensityMin = 5f;
    [SerializeField] private float _windIntensityMax = 10f;
    [SerializeField] private float _windSpeed = 5f;

    [Header("Earthquake")]
    [SerializeField] private float _shakeIntensityMin = 0.2f;
    [SerializeField] private float _shakeIntensityMax = 0.4f;
    [SerializeField] private float _shakeSpeed = 10f;
    [SerializeField] private GameObject _ground;

    [Space]
    public GameObject TileContainer;
    public Transform SpawnPosition;
    public List<GameObject> AllTiles = new List<GameObject>();//all avaliable tiles
    public List<Tile> TilesInInsecurity = new List<Tile>();
    public List<float> AllAngles = new List<float>() { 0, 90, 180, 270 };

    public void SpawnTile(CardType cardType)
    {
        int tChoice = Random.Range(0, AllTiles.Count);
        int angleChoice = Random.Range(0, AllAngles.Count);
        GameObject tile = Instantiate(AllTiles[tChoice], SpawnPosition.position, Quaternion.identity, TileContainer.transform);
        tile.transform.eulerAngles = new Vector3(0, 0, AllAngles[angleChoice]);
        tile.GetComponent<Tile>().cardType = cardType;

        TilesInInsecurity.Add(tile.GetComponent<Tile>());
    }

    public Tile GetRandomTile()
    {
        if (TilesInInsecurity.Count == 0)
            return null;

        var index = Random.Range(0, TilesInInsecurity.Count);
        var tile = TilesInInsecurity[index];
        TilesInInsecurity.RemoveAt(index);
        return tile;
    }

    public Tile GetHighestTile()
    {
        if (TilesInInsecurity.Count == 0)
            return null;

        var highest = TilesInInsecurity[0];
        foreach (var tile in TilesInInsecurity)
        {
            if (tile.transform.position.y > highest.transform.position.y)
                highest = tile;
        }
        TilesInInsecurity.Remove(highest);
        return highest;
    }

    public void MakeTileSlippery()
    {
        var tiles = new HashSet<TileCollider>();

        for (float i = -3f; i <= 3f; i += 0.25f)
        {
            if (Physics.Raycast(new Vector3(-50 + i, 20, 0), -transform.up, out var hit))
            {
                var tileCollider = hit.collider.GetComponent<TileCollider>();
                if (tileCollider != null)
                    tileCollider.BecomeSlippery();
            }
        }
    }

    public void MakeTileUnslippery()
    {
        foreach (var tile in TilesInInsecurity)
            tile.CollidersUnslippery();
    }

    public IEnumerator MakeTileSwinging()
    {
        for (int i = 0; i < 3; i++)
        {
            var time = 0f;
            var random = Random.Range(_windIntensityMin, _windIntensityMax);
            var intensity = i % 2 == 0 ? -random : random;
            while (time < 1f)
            {
                time += Time.deltaTime * _windSpeed;
                var force = Mathf.Lerp(intensity, 0, time);
                foreach (var tile in TilesInInsecurity)
                    tile.TileRB.AddForce(new Vector3(force, 0, 0));
                yield return null;
            }
        }
    }

    public IEnumerator MakeTileShaking()
    {
        var originalY = _ground.transform.position.y;
        var randomY = Random.Range(_shakeIntensityMin, _shakeIntensityMax);
        while (_ground.transform.position.y < originalY + randomY)
        {
            var movement = randomY * Time.deltaTime * _shakeSpeed;
            _ground.transform.Translate(new Vector3(0, movement, 0));
            yield return null;
        }
        randomY = Random.Range(_shakeIntensityMin, _shakeIntensityMax);
        while (_ground.transform.position.y > originalY - randomY)
        {
            var movement = -randomY * Time.deltaTime * _shakeSpeed;
            _ground.transform.Translate(new Vector3(0, movement, 0));
            yield return null;
        }
        while (_ground.transform.position.y < originalY)
        {
            var movement = randomY * Time.deltaTime * _shakeSpeed;
            _ground.transform.Translate(new Vector3(0, movement, 0));
            yield return null;
        }
        _ground.transform.localPosition = new Vector3(0, originalY, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpawnTile(CardType.none);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Destroy(GetRandomTile().gameObject);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Destroy(GetHighestTile().gameObject);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            StartCoroutine(MakeTileSwinging());
        if (Input.GetKeyDown(KeyCode.Alpha5))
            StartCoroutine(MakeTileShaking());
    }
}

public enum TileType
{
    O,
    T,
    L,
    rL,
    S,
    rS,
    I
}
