using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_FourTimeHappiness : Card
{
    public override void ActivateTruth()
    {
        CardManager.instance.DrawMultipleCards(4);
    }

    public override void ActivateDare()
    {
        CardManager.instance.DrawMultipleCards(4);
    }
}
