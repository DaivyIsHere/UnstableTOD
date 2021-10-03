using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_HundredSquats : Card
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
        //X pattern
        /*
        RealityManager.instance.NewTrap(new Vector3(-8,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,-4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,-4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-8), 1f, 0.5f);
        */
        RealityManager.instance.NewTrap(new Vector3(-4,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,-4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,-4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-4), 1f, 0.5f);
        /*
        //cross in the middle
        RealityManager.instance.NewTrap(new Vector3(0,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(1f)
        //up line down line;
        RealityManager.instance.NewTrap(new Vector3(-8,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(0,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(4,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        //left line right line;
        RealityManager.instance.NewTrap(new Vector3(-8,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,-4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-8), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-0), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,4), 1f, 0.5f);
        RealityManager.instance.NewTrap(new Vector3(8,0,8), 1f, 0.5f);
        */
        yield return 0;
    }
}
