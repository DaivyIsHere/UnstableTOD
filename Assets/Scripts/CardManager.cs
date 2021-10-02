using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    public List<GameObject> AllCards = new List<GameObject>();

    void Start() 
    {
        
    }

    void Update() 
    {
        
    }
}