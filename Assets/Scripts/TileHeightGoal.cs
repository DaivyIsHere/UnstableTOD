using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHeightGoal : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.transform.parent.GetComponent<Tile>())
        {
            Tile tile = other.transform.parent.GetComponent<Tile>();
            if(!tile.IsControlling)//In case it's still controlling
            {
                InsecurityManager.instance.DestroyAllTiles();
                print("Goal!");
            }
        }
    }
}
