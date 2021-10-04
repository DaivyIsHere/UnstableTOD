using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_StupidTiktokDance : Card
{
    public float ProjectileSpd = 5f;
    
    public override void ActivateTruth()
    {
        InsecurityManager.instance.SpawnTile(new CardSpawnData(cardType));
    }

    public override void ActivateDare()
    {
        RealityManager.instance.StartCoroutine(Dare());
    }

    public IEnumerator Dare()
    {
        for (int i = 0; i < 4; i++)
        {
            RealityManager.instance.NewProjectile(new Vector3(8,0,-4), 270, ProjectileSpd);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 4; i++)
        {
            RealityManager.instance.NewProjectile(new Vector3(-4,0,-8), 0, ProjectileSpd);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 4; i++)
        {
            RealityManager.instance.NewProjectile(new Vector3(-8,0,4), 90, ProjectileSpd);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 4; i++)
        {
            RealityManager.instance.NewProjectile(new Vector3(4,0,8), 180, ProjectileSpd);
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return 0;
    }
}
