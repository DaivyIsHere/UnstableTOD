using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public List<GameObject> AllCards = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {

    }

    public Card GetCardByType(CardType cardType)
    {
        foreach (var c in AllCards)
        {
            if (c.GetComponent<Card>().cardType == cardType)
                return c.GetComponent<Card>();
        }
        return null;
    }

    public TileType GetTileTypeByCardType(CardType cardType)
    {
        foreach (var c in AllCards)
        {
            if (c.GetComponent<Card>().cardType == cardType)
                return c.GetComponent<Card>().tileType;
        }
        return TileType.O;
    }

    public GameObject GetRandomCard()
    {
        int cChoice = 0;
        bool chosen = false;
        while (!chosen)
        {
            cChoice = Random.Range(0, AllCards.Count);
            if (AllCards[cChoice].GetComponent<Card>().minDrawCount <= GameManager.instance.drawCount)
            {
                float dice = Random.Range(0f, 1f);
                //print(AllCards[cChoice].name + " : " + AllCards[cChoice].GetComponent<Card>().possibilityMod);
                //print("dice = " + dice);
                if (AllCards[cChoice].GetComponent<Card>().possibilityMod > dice)
                {
                    chosen = true;
                    //print(true);
                }
            }
        }
        return AllCards[cChoice];
    }

    public void DrawMultipleCards(int cardCount)
    {
        List<Card> cards = new List<Card>();
        while (cards.Count < cardCount)
        {
            bool unique = true;
            Card newCard = CardManager.instance.GetRandomCard().GetComponent<Card>();
            if (newCard.cardUtilityType == CardUtilityType.Multiple)
            {
                unique = false;//do not add
            }
            else
            {
                foreach (var c in cards)
                {
                    if (c.cardType == newCard.cardType)
                    {
                        unique = false;
                    }
                }
            }
            if (unique)
                cards.Add(newCard);
        }

        foreach (var c in cards)
        {
            print("multiple dare " + c.name);
            c.ActivateDare();
        }
    }
}