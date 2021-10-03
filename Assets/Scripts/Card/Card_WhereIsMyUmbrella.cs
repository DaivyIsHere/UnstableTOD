using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_WhereIsMyUmbrella : Card
{
    public float slipperyDuration = 10f;
    
    public override void ActivateTruth()
    {
        RealityManager.instance.StartCoroutine(Slippery());
    }

    public override void ActivateDare()
    {
        RealityManager.instance.StartCoroutine(Slippery());
    }

    public IEnumerator Slippery()
    {
        PlayerMovement.instance.slippery = true;
        InsecurityManager.instance.MakeTileSlippery();
        yield return new WaitForSeconds(slipperyDuration);
        PlayerMovement.instance.slippery = false;
        InsecurityManager.instance.MakeTileUnslippery();
    }
}
