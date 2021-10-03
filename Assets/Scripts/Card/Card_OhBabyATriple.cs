using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_OhBabyATriple : Card
{
    public override void ActivateTruth()
    {
        CardManager.instance.DrawMultipleCards(3);
    }

    public override void ActivateDare()
    {
        CardManager.instance.DrawMultipleCards(3);
    }
}
