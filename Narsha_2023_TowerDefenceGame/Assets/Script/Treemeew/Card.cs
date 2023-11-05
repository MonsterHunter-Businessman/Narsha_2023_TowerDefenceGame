using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace park
{
    public class Card : MonoBehaviour
    {
        private int cardDamage;
        private int cardIndex;
        private string cardName;
        private string cardDescription;
        private string cardSprite;
        private int deckIndex;
        private Cards cardInfo;
        Deck cardDeck;
        public int childIndex;
        private string CardDescription
        {
            get { return cardDescription; }
            set { cardDescription = value; }
        }
        private string CardSprite
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
        private int CardIndex
        {
            get { return cardIndex; }
            set { cardIndex = value; }
        }


        void Start()
        {
            cardDeck = GetComponent<Deck>();
            cardInfo = GetComponent<Cards>();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("OnCollisionEnter2D");
            Card card = collision.gameObject.GetComponent<Card>();
            if (collision.gameObject.CompareTag("Slot"))
            {
                // �浹�� �� ������Ʈ ������
                GameObject slotObject = collision.gameObject;
                Deck slotDeck = slotObject.GetComponent<Deck>();

                // Deck ������Ʈ�� �ִ� ��쿡�� ���� ����
                if (slotDeck != null)
                {
                    // Deck ��ũ��Ʈ�� public ������ ������ �Ҵ�
                    slotDeck.cardName = cardInfo.cardNametxt;
                    slotDeck.cardDescription = cardInfo.cardInfo;
                    slotDeck.cardDamage = cardInfo.cardDmg;
                    slotDeck.cardSprite = cardInfo.cardSprite;
                    slotDeck.cardIndex = cardInfo.cardIndex;
                    Debug.Log("Card information transferred to the deck.");
                }
                childIndex = collision.gameObject.transform.GetSiblingIndex();
                DeckManager.Instance.deckList[childIndex] = slotDeck;
                DeckManager.Instance.SaveCardData(slotDeck, childIndex);

            }



        }
    }
}
