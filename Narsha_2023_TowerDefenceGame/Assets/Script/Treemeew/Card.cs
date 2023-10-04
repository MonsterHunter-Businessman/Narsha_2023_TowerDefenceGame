using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int cardDamage;
    private string cardName;
    private string cardDescription;
    private Sprite cardSprite;
    Deck cardDeck;
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
 

    void Start()
    {
        cardDeck = GetComponent<Deck>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        Card card = collision.gameObject.GetComponent<Card>();
        if (collision.gameObject.CompareTag("Slot"))
        {
            DeckManager.Instance.LoadCardInfo(4);
            Debug.Log("dd");
        }
    }
}
