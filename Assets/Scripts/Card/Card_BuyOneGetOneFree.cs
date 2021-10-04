using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_BuyOneGetOneFree : Card
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
        CardManager.instance.DrawMultipleCards(2);
    }

    public IEnumerator delayTile()
    {
        yield return new WaitForSeconds(1.5f);
        CardManager.instance.DrawBigTileCard(1.25f);
    }
}
