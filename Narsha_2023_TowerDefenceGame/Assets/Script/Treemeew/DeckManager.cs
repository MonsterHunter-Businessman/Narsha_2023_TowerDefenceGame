using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance = null;
    public GameObject[] decks;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadCardInfo(int deckIndex)
    {
        decks[deckIndex].GetComponent<Deck>().cardName = "nun";
        decks[deckIndex].GetComponent<Deck>().cardDescription = "its nun card";
        decks[deckIndex].GetComponent<Deck>().cardDamage = 10;
        decks[deckIndex].GetComponent<Deck>().cardSprite = "Treemeew";
    }
}
