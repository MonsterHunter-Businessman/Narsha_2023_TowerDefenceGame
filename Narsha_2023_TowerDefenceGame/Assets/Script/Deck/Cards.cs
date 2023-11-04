using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    darkmagician
}

public class Cards : MonoBehaviour
{
    public int cardIndex;
    public TextMeshProUGUI cardname;
    public TextMeshProUGUI cardDescriptionTxt;
    public TowerCards TowerCard;
    public int cardDmg;
    public string cardNametxt;
    public string cardInfo;
    public GameObject cardImage;
    public string cardSprite;


    private void Start()
    {

    }

    void Update()
    {    
        mercenaryType();
        cardname.text = cardNametxt;
        cardDescriptionTxt.text = cardInfo;
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
        }
  
    }

}

