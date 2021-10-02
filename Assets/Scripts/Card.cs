using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject showText;

    //3d texture
    public CardType cardType;
    public Sprite sprite;

    void Start() 
    {
        
    }

    public virtual void ActivateTruth()
    {
        print("Truth!");
        InsecurityManager.instance.SpawnTile(cardType);
    }

    public virtual void ActivateDare()
    {
        print("Dare!");
    }


}

public enum CardType
{
    none,
    LoveAndCare,

}
