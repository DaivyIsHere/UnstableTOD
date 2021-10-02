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

    public GameObject TileContainer;
    public Transform SpawnPosition;
    public List<GameObject> AllTiles = new List<GameObject>();//all avaliable tiles
    public List<GameObject> TilesInInsecurity = new List<GameObject>();
    public List<float> AllAngles = new List<float>() { 0, 90, 180, 270 };

    public void SpawnTile(CardType cardType)
    {
        int tChoice = Random.Range(0, AllTiles.Count);
        int angleChoice = Random.Range(0, AllAngles.Count);
        GameObject tile = Instantiate(AllTiles[tChoice], SpawnPosition.position, Quaternion.identity, TileContainer.transform);
        tile.transform.eulerAngles = new Vector3(0, 0, AllAngles[angleChoice]);
        tile.GetComponent<Tile>().cardType = cardType;

        TilesInInsecurity.Add(tile);
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
