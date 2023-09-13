using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int cardDamage;
    private string cardName;
    private string cardDescription;
    private Sprite cardSprite;

    private string CardDescription
    {
        get { return cardDescription; }
        set { cardDescription = value; }
    }
    private Sprite CardSprite
    {
        get { return cardSprite; }
        set { cardSprite = value; }
    }
    private string CardName
    {
        get { return cardName; }
        set { cardName = value; }
    }
    private int CardDamage
    {
        get { return cardDamage; }

        set { cardDamage = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
