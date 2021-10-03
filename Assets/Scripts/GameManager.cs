using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    public int maxSanity = 3;
    public int playerSanity = 3;

    void Start() 
    {
        playerSanity = maxSanity;
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
