using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_IceBucket : Card
{
    public override void ActivateTruth()
    {
        InsecurityManager.instance.SpawnTile(cardType);
    }

    public override void ActivateDare()
    {
        RealityManager.instance.StartCoroutine(RealityManager.instance.Card_IceBucket());
    }
}
