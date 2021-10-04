using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_IceBucket : Card
{
    public float ProjectileSpd = 3f;
    
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
        RealityManager.instance.NewProjectile(Vector3.zero, 0, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 45, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 90, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 135, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 180, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 225, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 270, ProjectileSpd);
        RealityManager.instance.NewProjectile(Vector3.zero, 315, ProjectileSpd);
        yield return 0;
    }
}
