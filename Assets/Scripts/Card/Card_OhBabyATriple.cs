using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_OhBabyATriple : Card
{
    public override void ActivateTruth()
    {
        CardManager.instance.StartCoroutine(delayTile());
    }

    public override void ActivateDare()
    {
        CardManager.instance.StartCoroutine(delayDraw());
    }

    public IEnumerator delayDraw()
    {
        yield return new WaitForSeconds(1.5f);
        CardManager.instance.DrawMultipleCards(3);
    }

    public IEnumerator delayTile()
    {
        yield return new WaitForSeconds(1.5f);
        CardManager.instance.DrawBigTileCard(2f);
    }
}
