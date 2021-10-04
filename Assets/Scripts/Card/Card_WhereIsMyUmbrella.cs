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
        GameManager.instance.SlipperyDisplay.enabled = true;
        PlayerMovement.instance.slippery = true;
        InsecurityManager.instance.MakeTileSlippery();
        yield return new WaitForSeconds(slipperyDuration);
        GameManager.instance.SlipperyDisplay.enabled = false;
        PlayerMovement.instance.slippery = false;
        InsecurityManager.instance.MakeTileUnslippery();
    }
}
