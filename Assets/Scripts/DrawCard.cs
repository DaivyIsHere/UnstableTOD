using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public Camera realityCam;
    public bool IsHoldingCard = false;
    public float CardHoldY = 3f;
    public Transform SpawnPosition;
    public GameObject newCard;
    public GameObject cardHolding;

    public float truthX;
    public float dareX;

    // Start is called before the first frame update
    void Start()
    {
        RespawnCard();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = realityCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.tag == "Card")
                {
                    cardHolding = hit.transform.gameObject;
                    IsHoldingCard = true;
                    //print(hit.transform.gameObject.name);
                }
            }
        }

        if (Input.GetMouseButton(0) && IsHoldingCard)
        {
            Plane plane = new Plane(transform.up, -3f);
            Ray ray = realityCam.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if (plane.Raycast(ray, out distanceToPlane))
            {
                Vector3 pos = ray.GetPoint(distanceToPlane);
                //print(pos);
                Vector3 targetPos = new Vector3(pos.x, CardHoldY, pos.z);
                Quaternion targetAngles = Quaternion.Euler(-20, 0, 0);
                
                cardHolding.transform.position = Vector3.Lerp(cardHolding.transform.position, targetPos, 0.1f);
                cardHolding.transform.rotation = Quaternion.Lerp(cardHolding.transform.rotation, targetAngles, 0.1f);
            }

            if(cardHolding.transform.position.x < truthX)
            {
                //show truth
                cardHolding.GetComponent<Card>().showText.SetActive(true);
                cardHolding.GetComponent<Card>().showText.GetComponent<TextMesh>().text = "Truth";
            }
            else if(cardHolding.transform.position.x > dareX)
            {
                //show dareX;
                cardHolding.GetComponent<Card>().showText.SetActive(true);
                cardHolding.GetComponent<Card>().showText.GetComponent<TextMesh>().text = "Dare";
            }
            else
            {
                cardHolding.GetComponent<Card>().showText.SetActive(false);
                //reset;
            }
        }

        if (Input.GetMouseButtonUp(0) && IsHoldingCard)
        {
            if(cardHolding.transform.position.x < truthX)
            {
                //truth
                ApplyTruthCard();
                DestroyCard();
                RespawnCard();
            }
            else if(cardHolding.transform.position.x > dareX)
            {
                //dare;
                ApplyDareCard();
                DestroyCard();
                RespawnCard();
            }
            else
            {
                //drop;
            }

            IsHoldingCard = false;
            cardHolding = null;
        }

        if(!IsHoldingCard)
        {
            newCard.transform.position = Vector3.Lerp(newCard.transform.position, SpawnPosition.position, 0.1f);
            newCard.transform.rotation = Quaternion.Lerp(newCard.transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
        }
    }


    public void ApplyTruthCard()
    {
        print("Truth : "+cardHolding.GetComponent<Card>().cardType);
        cardHolding.GetComponent<Card>().ActivateTruth();
    }

    public void ApplyDareCard()
    {
        print("Dare : "+cardHolding.GetComponent<Card>().cardType);
        cardHolding.GetComponent<Card>().ActivateDare();
    }

    public void DestroyCard()
    {
        Destroy(cardHolding.gameObject);
        newCard = null;
    }

    public void RespawnCard()
    {
        if(newCard == null)
            newCard = Instantiate(CardManager.instance.GetRandomCard(), SpawnPosition.position, Quaternion.identity, transform.parent);
    }
}
