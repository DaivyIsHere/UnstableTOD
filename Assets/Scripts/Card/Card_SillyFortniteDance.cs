using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_SillyFortniteDance : Card
{
    public override void ActivateTruth()
    {
        InsecurityManager.instance.SpawnTile(cardType);
    }

    public override void ActivateDare()
    {
        RealityManager.instance.StartCoroutine(Dare());
    }

    public IEnumerator Dare()
    {
        //cross in the middle
        RealityManager.instance.NewTrap(new Vector3(0,0,4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,0), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(0,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(4,0,0), 1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 5; i++)
        {
            RealityManager.instance.NewTrap(new Vector3(-8+(i*4),0,8), 1f, 0.5f);
            RealityManager.instance.NewTrap(new Vector3(8-(i*4),0,-8), 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return 0;
    }
}
