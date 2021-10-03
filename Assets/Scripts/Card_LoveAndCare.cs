using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_LoveAndCare : Card
{
    public override void ActivateTruth()
    {
        GameManager.instance.PlayerAddSanity();
        //print("Truth!");
        //InsecurityManager.instance.SpawnTile(cardType);
    }
}
