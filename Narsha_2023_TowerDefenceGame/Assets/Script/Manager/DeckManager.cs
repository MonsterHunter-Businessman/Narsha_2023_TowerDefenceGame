using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


namespace park
{
    public class DeckManager : MonoBehaviour
    {
        public static DeckManager Instance = null;
        public Deck[] deckList;
        public Card card;
        public Cards cards;

        //ethan
        public GameObject cardObj;

        private bool isInitialized = false;
        [SerializeField] private CardData[] cardData;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Debug.Log("DontDestroyOnLoad");
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Destroy");
            }
        }

        private void Start()
        {
            deckList = new Deck[5];

            Deck[] decks = new Deck[5];
            for (int i = 0; i < 5; i++)
            {
                decks[i] = new Deck();
            }

            decks[card.childIndex].cardName = card.name;

        }

        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "Ingame")
            {
                LoadCardInfo();
            }
        }

        public void LoadCardInfo()
        {
            cardObj = GameObject.FindWithTag("cardObj");
            //card = FindAnyObjectByType<Card>();
            //cards = FindAnyObjectByType<Cards>();
            for (int i = 0; i < deckList.Length; i++)
            {
                if (deckList[i] == null)
                {

                    deckList[i] = null;
                    deckList[i] = cardObj.transform.GetChild(i).GetComponent<Deck>();

                }
                deckList[i].cardName = cardData[i].cardName;
                deckList[i].cardDamage = cardData[i].cardDamage;
                deckList[i].cardDescription = cardData[i].cardDescription;
                deckList[i].cardSprite = cardData[i].cardSprite;
                deckList[i].cardIndex = cardData[i].cardIndex;
            }
        }

        public void SaveCardData(Deck deck, int index)
        {
            cardData[index].cardName = deck.cardName;
            cardData[index].cardDamage = deck.cardDamage;
            cardData[index].cardDescription = deck.cardDescription;
            cardData[index].cardSprite = deck.cardSprite;
            cardData[index].cardIndex = deck.cardIndex;
        }

    }
    [System.Serializable]
    public class CardData
    {
        public string cardName;
        public string cardDescription;
        public string cardSprite;
        public int cardDamage;
        public int cardIndex;
    }
}
