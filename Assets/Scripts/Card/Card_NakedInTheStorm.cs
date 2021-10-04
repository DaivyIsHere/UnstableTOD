using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_NakedInTheStorm : Card
{
    public override void ActivateTruth()
    {
        InsecurityManager.instance.StartCoroutine(InsecurityManager.instance.MakeTileSwinging());
    }

    public override void ActivateDare()
    {
        InsecurityManager.instance.StartCoroutine(InsecurityManager.instance.MakeTileSwinging());
    }
}
