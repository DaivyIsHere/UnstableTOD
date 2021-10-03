using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFallDetect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.GetComponent<Tile>())
        {
            Tile tile = other.transform.parent.GetComponent<Tile>();
            if(tile.IsControlling)//In case it's still controlling
            {
                InsecurityManager.instance.TilesInInsecurity.Add(tile);
                InsecurityManager.instance.controllingTile = null;
            }
            InsecurityManager.instance.TilesInInsecurity.Remove(tile);
            CardType cardType = tile.cardType;
            Destroy(tile.gameObject);
            Card c = CardManager.instance.GetCardByType(cardType);
            c.ActivateDare();
            print("Fell : "+cardType);
        }
    }
}
