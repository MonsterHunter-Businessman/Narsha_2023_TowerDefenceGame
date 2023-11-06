using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;
using TMPro;

//개선사항이 많이 필요
public enum TowerCards
{
    none,
    nun,
    assassin,
    spear,
    berserker,
    darkmagician,
    knight,
    wizzard,
    archer
}

public class Cards : MonoBehaviour
{
    public int cardIndex;
    public TextMeshProUGUI cardname;
    public TextMeshProUGUI cardDescriptionTxt;
    public TowerCards TowerCard;
    public float cardDmg;
    public string cardNametxt;
    public string cardInfo;
    public GameObject cardImage;
    public string cardSprite;
    public float maxHp;
    public float fireTime;
    public Vector3 fireRange;
    public Animator cardAnim;
    public string animPath;
    
    void Update()
    {    
        mercenaryType();
        cardname.text = cardNametxt;
        cardDescriptionTxt.text = cardInfo;

        
        /*cardNametxt = DeckManager.Instance.deckList[1].cardName;
        cardDmg = DeckManager.Instance.deckList[1].cardDamage;
        cardInfo = DeckManager.Instance.deckList[1].cardDescription;
        cardSprite = DeckManager.Instance.deckList[1].cardSprite;*/
    }


    public void mercenaryType()
    {
        switch (cardIndex)
        {
            case 0:
                TowerCard = TowerCards.none;
                break;
            case 1:
                TowerCard = TowerCards.nun;
                break;
            case 2:
                TowerCard = TowerCards.assassin;
                break;
            case 3:
                TowerCard = TowerCards.spear;
                break;
            case 4:
                TowerCard = TowerCards.berserker;
                break;
            case 5:
                TowerCard = TowerCards.darkmagician;
                break;
            case 6:
                TowerCard = TowerCards.knight;
                break;
            case 7:
                TowerCard = TowerCards.wizzard;
                break;
            case 8:
                TowerCard = TowerCards.archer;
                break;
            default:
                TowerCard = TowerCards.none;
                break;
        }
        switch (TowerCard)
        {
            case TowerCards.nun:
                cardNametxt = "사제";
                cardInfo = " 10초마다 아군의 체력을 5회복 합니다.적을 단일 공격합니다.";
                cardSprite = "Img/Ch/Player/nun";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 7;
                break;
            case TowerCards.assassin:
                cardNametxt = "암살자";
                cardInfo = " 상대에게 공격을 받지 않습니다.적을 단일 공격합니다";
                cardSprite = "Img/Ch/Player/assassin";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 15;
                break;
            case TowerCards.spear:
                cardNametxt = "창병";
                cardInfo = "상대의 어그로를 우선으로 먹습니다.적을 단일 공격합니다.";
                cardSprite = "Img/Ch/Player/spear";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 10;
                break;
            case TowerCards.berserker:
                cardNametxt = "광전사";
                cardInfo = "상대의 어그로를 우선으로 먹습니다.적을 단일 공격합니다.";
                cardSprite = "Img/Ch/Player/berserker";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 20;
                break;
            case TowerCards.darkmagician:
                cardNametxt = "흑마법사";
                cardInfo = "공격한 칸 4칸내에 있는 적에게 광역 피해를 입힙니다.";
                cardSprite = "Img/Ch/Player/darkmagician";
                cardImage.GetComponent <Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 20;
                break;
            case TowerCards.knight:
                cardNametxt = "기사";
                cardInfo = "세상 평범한 기사입니다. 적을 단일 공격합니다.";
                cardSprite = "Img/Ch/Player/Knight.png";
                animPath = "Animations/Control/MainCharacter.controller";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardAnim.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animPath);
                cardDmg = 10;
                break;
            case TowerCards.wizzard:
                cardNametxt = "마법사";
                cardInfo = "마법사이빈다.";
                cardSprite = "";
                animPath = "";
                break;
        }
  
    }

}

