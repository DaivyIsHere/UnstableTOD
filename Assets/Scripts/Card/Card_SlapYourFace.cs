using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_SlapYourFace : Card
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
        for (int i = 0; i < 20; i++)
        {
            if (i == 7 || i == 8 ||i == 13 || i == 14)
            {
                //skip
            }
            else
            {
                RealityManager.instance.NewProjectile(new Vector3(i, 0, 20 - i), 225, ProjectileSpd);
            }
        }
        yield return 0;
    }
}
