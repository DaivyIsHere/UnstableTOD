using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_UndergroundDanceParty : Card
{
    public override void ActivateTruth()
    {
        InsecurityManager.instance.StartCoroutine(InsecurityManager.instance.MakeTileShaking());
    }

    public override void ActivateDare()
    {
        InsecurityManager.instance.StartCoroutine(InsecurityManager.instance.MakeTileShaking());
    }
}
