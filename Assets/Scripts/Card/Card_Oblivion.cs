using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Oblivion : Card
{
    [SerializeField] private GameObject _particle;

    public override void ActivateTruth()
    {
        Tile t = InsecurityManager.instance.GetRandomTile();

        //play effect
        Instantiate(_particle, t.transform.position, Quaternion.identity);

        if(t)
            Destroy(t.gameObject, 0.5f);

    }

    public override void ActivateDare()
    {
        Tile t = InsecurityManager.instance.GetHighestTile();

        //play effect
        Instantiate(_particle, t.transform.position, Quaternion.identity);

        if(t)
            Destroy(t.gameObject, 0.5f);
    }
}
