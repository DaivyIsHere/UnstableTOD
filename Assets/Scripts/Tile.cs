using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType tileType;
    public CardType cardType;
    public bool IsControlling;

    void Update() 
    {
        if(IsControlling)
        {
            //drop
            //Q E to rotate
        }    
    }
}
