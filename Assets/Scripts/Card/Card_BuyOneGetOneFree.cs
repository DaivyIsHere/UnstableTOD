using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_BuyOneGetOneFree : Card
{
    public override void ActivateTruth()
    {
        CardManager.instance.DrawMultipleCards(2);
    }

    public override void ActivateDare()
    {
        CardManager.instance.DrawMultipleCards(2);
    }
}