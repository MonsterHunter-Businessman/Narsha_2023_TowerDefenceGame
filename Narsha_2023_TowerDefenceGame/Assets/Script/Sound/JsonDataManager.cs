using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDataManager : MonoBehaviour
{
    public static JsonDataManager instance = null;

    [Serializable]
    public struct Enemy
    {
        public string tag; //���� �̸�
        public int health; //���� hp
        public int fireTime;
        public int fireRange;
        public string changImg;
        public string bullet;
        public int speed;

        public Enemy(string tag, int health, int fireTime, int fireRange, string changImg, string bullet, int speed)
        {
            this.tag = tag;
            this.health = health;
            this.fireTime = fireTime;
            this.fireRange = fireRange;
            this.changImg = changImg;
            this.bullet = bullet;
            this.speed = speed;
        }
    }

    [Serializable]
    public struct Card
    {
        public string Name; //Ÿ�� �̸�
        public string Description;
        public int Damage;
        public string SpritePath;
        
        public Card(string Name, string Description, int Damage, string SpritePath)
        {
            this.Name = Name;
            this.Description = Description;
            this.Damage = Damage;
            this.SpritePath = SpritePath;
        }
    }
    [Serializable]
    public struct Support
    {
        public string Name; //����ī���� �̸�
        public string Info; //����ī���� ���� : ex) ���� ������, ���� 5hp�� ȸ���մϴ�.
        public int AttRange; //����ī�� ���ݹ���
        public int Att; //����ī�� ���ݷ�
        public string ImgPath; //����ī�� �̹��� ���

        public Support(string Nmae, string Info, int AttRange, int Att, string ImgPath)
        {
            this.Name = Nmae;
            this.Info = Info;
            this.AttRange = AttRange;
            this.Att = Att;
            this.ImgPath = ImgPath;
        }
    }

    public class EnemyDatas
    {
        public List<Enemy> Enemy;
    }


    public class CardDatas
    {
        public List<Card> Card;
    }


    public class SupportDatas
    {
        public List<Support> Support;
    }

    public EnemyDatas enemyData;
    public CardDatas cardData;
    public SupportDatas supportData;

    public Enemy Goblin;
    public Enemy Slime;
    public Enemy RobberGoblin;
    public Enemy Imp;
    public Enemy Ork;
    public Enemy Golem;
    public Enemy Spider;
    public Enemy Devil;
    public Enemy PhantomKnight;
    public Enemy KingSlime;
    public Enemy OrkChief;
    public Enemy KingPhantom;

    public Card spear;
    public Card archer;
    public Card shield;
    public Card magician;
    public Card holyknight;
    public Card berserker;
    public Card assassin;
    public Card nun;
    public Card blackmagician;
    public Card druid;
    public Card banyukwang;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Json/EnemyData");
        enemyData = JsonUtility.FromJson<EnemyDatas>(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Json/CardData");
        cardData = JsonUtility.FromJson<CardDatas>(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Json/SupportData");
        supportData = JsonUtility.FromJson<SupportDatas>(textAsset.text);

        Goblin = MonsterParsing("goblin"); 
        Slime = MonsterParsing("slime");
        RobberGoblin = MonsterParsing("robberGoblin");
        Imp = MonsterParsing("imp");
        Ork = MonsterParsing("ork");
        Golem = MonsterParsing("golem");
        Spider = MonsterParsing("spider");
        Devil = MonsterParsing("devil");
        PhantomKnight = MonsterParsing("phantomKnight");
        KingSlime = MonsterParsing("kingSlime");
        OrkChief = MonsterParsing("orkChief");
        KingPhantom = MonsterParsing("kingPhantom");

        spear = CardParsing("â��");
        archer = CardParsing("�ü�");
        shield = CardParsing("���к�");
        magician = CardParsing("������");
        holyknight = CardParsing("�����");
        berserker = CardParsing("������");
        assassin = CardParsing("�ϻ���");
        nun = CardParsing("����");
        blackmagician = CardParsing("�渶����");
        druid = CardParsing("����̵�");
        banyukwang = CardParsing("�ݿ���");
    }

    public Enemy MonsterParsing(string tag)
    {
        Enemy enemy1 = new Enemy("", 0, 0, 0, "", "", 0);
        foreach (Enemy enemy in enemyData.Enemy)
        {
            if (enemy.tag == tag)
            {
                enemy1 = enemy;
                break;
            }
        }
        return enemy1;
    }

    public Card CardParsing(string name)
    {
        Card card1 = new Card("", "", 0, "");
        foreach (Card card in cardData.Card)
        {
            if (card.Name == name)
            {
                card1 = card;
                break;
            }
        }
        return card1;
    }

    public Support SupportParsing(string name)
    {
        Support support1 = new Support("", "", 0, 0, "");
        foreach (Support support in supportData.Support)
        {
            if (support.Name == name)
            {
                support1 = support;
                break;
            }
        }
        return support1;
    }
}