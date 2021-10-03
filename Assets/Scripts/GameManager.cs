using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    public Text sanityDisplay;
    public int maxSanity = 3;
    public int playerSanity = 3;

    void Start() 
    {
        playerSanity = maxSanity;
    }

    void Update() 
    {    
        sanityDisplay.text = "Sanity = "+playerSanity;
    }

    public void PlayerTakeDamage()
    {
        if(playerSanity > 0)
        {
            playerSanity --;
        }
    }

    public void PlayerAddSanity()
    {
        if(playerSanity < maxSanity)
        {
            playerSanity ++;
        }
    }
    
}
