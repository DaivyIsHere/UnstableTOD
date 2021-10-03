using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [HideInInspector]public GameObject showText;

    //3d texture
    public CardType cardType;
    public CardUtilityType cardUtilityType;
    public TileType tileType;
    public Sprite sprite;

    [Range(0,1)]
    public float possibilityMod = 1;
    public int minDrawCount = 0;

    private void Awake() 
    {
        showText = GetComponentInChildren<TextMesh>(true).gameObject;
    }

    void Start() 
    {
        
    }

    public virtual void ActivateTruth()
    {
        
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
    BuyOneGetOneFree,
    OhBabyATriple,
    FourTimesHappiness
}

public enum CardUtilityType
{
    Bullet,
    Trap,
    Weather,
    Utility,
    Multiple,
}
