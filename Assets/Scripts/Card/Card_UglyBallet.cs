using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_UglyBallet : Card
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
        //small O
        RealityManager.instance.NewTrap(new Vector3(-4,0,4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,0), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(0,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(4,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(4,0,0), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(4,0,4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(0,0,4), 1f, 0.5f);
        //big O
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,0), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-8,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);

        RealityManager.instance.NewTrap(new Vector3(-4,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-0,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(4,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(8,0,-8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);

        RealityManager.instance.NewTrap(new Vector3(8,0,-4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(8,0,0), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(8,0,4), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(8,0,8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);

        RealityManager.instance.NewTrap(new Vector3(4,0,8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(0,0,8), 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        RealityManager.instance.NewTrap(new Vector3(-4,0,8), 1f, 0.5f);
    }
}
