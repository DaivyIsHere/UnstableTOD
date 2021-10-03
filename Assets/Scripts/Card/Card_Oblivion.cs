using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Oblivion : Card
{
    public override void ActivateTruth()
    {
        //play effect
        Tile t = InsecurityManager.instance.GetRandomTile();
        if(t)
            Destroy(t.gameObject, 0.5f);
    }

    public override void ActivateDare()
    {
        //play effect
        Tile t = InsecurityManager.instance.GetHighestTile();
        if(t)
            Destroy(t.gameObject, 0.5f);
    }
}
