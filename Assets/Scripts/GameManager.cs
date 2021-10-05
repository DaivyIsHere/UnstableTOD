using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    public TextMesh drawCountDisplay;
    public Text sanityDisplay;
    public Text SlipperyDisplay;
    public int startSanity = 3;
    public int maxSanity = 5;
    public int playerSanity = 3;

    public int drawCount = 0;
    public float tileDropSpeed = 2;

    void Start() 
    {
        SlipperyDisplay.enabled = false;
        playerSanity = startSanity;
        drawCount = 0;
    }

    void Update() 
    {    
        drawCountDisplay.text = drawCount.ToString();
        PlayerSanityDisplay();    
        ChangeTileSpeed();
        
        if(playerSanity == 0)
        {
            GameOver();
        }
    }

    public void PlayerSanityDisplay()
    {
        sanityDisplay.text = "Sanity = "+playerSanity;
        /*
        if(playerSanity == 0)
        {
            sanityDisplay.text = "Sanity = X";
            GameOver();
        }
        else if(playerSanity == 1)
        {
            sanityDisplay.text = "Sanity = O";
        }
        else if(playerSanity == 2)
        {
            sanityDisplay.text = "Sanity = OO";
        }
        else if(playerSanity == 3)
        {
            sanityDisplay.text = "Sanity = OOO";
        }
        else if(playerSanity == 4)
        {
            sanityDisplay.text = "Sanity = OOOO";
        }
        else if(playerSanity == 5)
        {
            sanityDisplay.text = "Sanity = OOOOO";
        }
        */
    }

    public void ChangeTileSpeed()
    {
        if(drawCount > 50)
        {
            tileDropSpeed = 5f;
        }
        else if(drawCount > 40)
        {
            tileDropSpeed = 4f;
        }
        else if(drawCount > 30)
        {
            tileDropSpeed = 3f;
        }
        else
        {
            tileDropSpeed = 2f;
        }
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
    
    private void GameOver()
    {
        GameRecord.Draw = drawCount;
        GameRecord.Time = Time.timeSinceLevelLoad;
        SceneManager.LoadScene(2);
    }
}
