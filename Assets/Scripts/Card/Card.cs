using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [HideInInspector]public GameObject showText;

    //3d texture
    public CardType cardType;
    public Sprite sprite;

    private void Awake() 
    {
        showText = GetComponentInChildren<TextMesh>(true).gameObject;
    }

    void Start() 
    {
        
    }

    public virtual void ActivateTruth()
    {
        InsecurityManager.instance.SpawnTile(cardType);
    }

    public virtual void ActivateDare()
    {
        
    }


}

public enum CardType
{
    none,
    LoveAndCare,
    Oblivion,
    Observation,
    IceBucket,
    CarWashMachine,
    SlapYourself,
    HundredSquats,
    EyeClose,
    UglyBallet,
    SillyForniteDance,
    StupidTiktokDance,
    NakedInTheStorm,
    WhereIsMyUmbrella,
    UndergroundDanceParty,
}
