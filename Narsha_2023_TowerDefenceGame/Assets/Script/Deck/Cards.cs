using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//���������� ���� �ʿ�
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
                cardNametxt = "����";
                cardInfo = " 10�ʸ��� �Ʊ��� ü���� 5ȸ�� �մϴ�.���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/nun";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 7;
                break;
            case TowerCards.assassin:
                cardNametxt = "�ϻ���";
                cardInfo = " ��뿡�� ������ ���� �ʽ��ϴ�.���� ���� �����մϴ�";
                cardSprite = "Img/Ch/Player/assassin";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 15;
                break;
            case TowerCards.spear:
                cardNametxt = "â��";
                cardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/spear";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 10;
                break;
            case TowerCards.berserker:
                cardNametxt = "������";
                cardInfo = "����� ��׷θ� �켱���� �Խ��ϴ�.���� ���� �����մϴ�.";
                cardSprite = "Img/Ch/Player/berserker";
                cardImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 20;
                break;
            case TowerCards.darkmagician:
                cardNametxt = "�渶����";
                cardInfo = "������ ĭ 4ĭ���� �ִ� ������ ���� ���ظ� �����ϴ�.";
                cardSprite = "Img/Ch/Player/darkmagician";
                cardImage.GetComponent <Image>().sprite = Resources.Load<Sprite>(cardSprite);
                cardDmg = 20;
                break;
        }
  
    }

}

