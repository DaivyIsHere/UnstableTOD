using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_BuyOneGetOneFree : Card
{
    public override void ActivateTruth()
    {
        CardManager.instance.StartCoroutine(delayDraw());
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
}
