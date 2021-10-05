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
    public List<string> AllDialog = new List<string>();
    private float DialogCD = 0;//Count down

    public Transform DisplayCenter;
    public GameObject DisplayTextPref;
    public Queue<CardDisplayData> cardDisplayQueue = new Queue<CardDisplayData>();
    public Color32 whiteText;
    public Color32 blueText;
    public Color32 redText;
    public Color32 yellowText;

    void Start()
    {
        StartCoroutine(DisplayQueue());
    }

    void Update()
    {
        ClearDialog();
    }

    public void DisplayRandomDialog()
    {
        int c = Random.Range(0, AllDialog.Count);
        PlayerMovement.instance.dialogText.text = AllDialog[c];
        PlayerMovement.instance.dialogText.text= PlayerMovement.instance.dialogText.text.Replace("\\n","\n");
        PlayerMovement.instance.dialogText.gameObject.SetActive(true);
        DialogCD = 2f;
    }

    public void ClearDialog()
    {
        if(DialogCD <= 0)
        {
            PlayerMovement.instance.dialogText.text = "";
            PlayerMovement.instance.dialogText.gameObject.SetActive(false);
        }
        else
        {
            DialogCD -= Time.deltaTime;
        }
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
            CardManager.instance.cardDisplayQueue.Enqueue(new CardDisplayData(c.cardUtilityType, c.description));
            c.ActivateDare();
        }
    }

    public void DrawBigTileCard(float scaleValue)
    {
        Card newCard = null;
        bool pass = false;
        while (!pass)
        {
            newCard = CardManager.instance.GetRandomCard().GetComponent<Card>();
            if (newCard.cardUtilityType != CardUtilityType.Multiple)
            {
                pass = true;//do not add
            }
        }
        CardManager.instance.cardDisplayQueue.Enqueue(new CardDisplayData(newCard.cardUtilityType, newCard.description));
        InsecurityManager.instance.SpawnTile(new CardSpawnData(newCard.cardType, scaleValue));
    }

    public IEnumerator DisplayQueue()
    {
        while (true)
        {
            if (cardDisplayQueue.Count > 0)
            {
                CardDisplayData data = cardDisplayQueue.Dequeue();
                GameObject displayText = Instantiate(DisplayTextPref, DisplayCenter, false);
                displayText.transform.eulerAngles = new Vector3(65, 0, 0);
                displayText.GetComponent<TextMesh>().text = data.description;
                if(data.cardUtilityType == CardUtilityType.Bullet || data.cardUtilityType == CardUtilityType.Trap )
                {
                    displayText.GetComponent<TextMesh>().color = whiteText;
                }
                else if(data.cardUtilityType == CardUtilityType.Multiple)
                {
                    displayText.GetComponent<TextMesh>().color = yellowText;
                }
                else if(data.cardUtilityType == CardUtilityType.Utility)
                {
                    displayText.GetComponent<TextMesh>().color = redText;
                }
                else if(data.cardUtilityType == CardUtilityType.Weather)
                {
                    displayText.GetComponent<TextMesh>().color = blueText;
                }


                if (cardDisplayQueue.Count == 0)
                {
                    yield return new WaitForSeconds(1.5f);
                }
                else
                {
                    yield return new WaitForSeconds(0.2f);
                }
                displayText.GetComponent<Animation>().Play("CardDisplayOut");
                yield return new WaitForSeconds(0.2f);
                Destroy(displayText);
            }
            yield return 0;
        }
    }
}

public class CardDisplayData
{
    public CardUtilityType cardUtilityType;
    public string description;

    public CardDisplayData(CardUtilityType type, string description)
    {
        cardUtilityType = type;
        this.description = description;
    }
}