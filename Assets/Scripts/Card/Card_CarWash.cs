using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_CarWash : Card
{
    public float ProjectileSpd = 3f;
    
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
        for (int i = 0; i < 9; i++)
        {
            RealityManager.instance.NewProjectile(Vector3.zero, 315+i*10, ProjectileSpd);
            RealityManager.instance.NewProjectile(Vector3.zero, 135+i*10, ProjectileSpd);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSecondsRealtime(1f);
        for (int i = 0; i < 9; i++)
        {
            RealityManager.instance.NewProjectile(Vector3.zero, 45+i*10, ProjectileSpd);
            RealityManager.instance.NewProjectile(Vector3.zero, 225+i*10, ProjectileSpd);
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return 0;
    }
}
