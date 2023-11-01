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
        public string tag; //적의 이름
        public int health; //적의 hp
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
        public string Name; //타워 이름
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
        public string Name; //지원카드의 이름
        public string Info; //지원카드의 설명 : ex) 성을 수리해, 성이 5hp를 회복합니다.
        public int AttRange; //지원카드 공격범위
        public int Att; //지원카드 공격력
        public string ImgPath; //지원카드 이미지 경로

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

        spear = CardParsing("창병");
        archer = CardParsing("궁수");
        shield = CardParsing("방패병");
        magician = CardParsing("마법사");
        holyknight = CardParsing("성기사");
        berserker = CardParsing("광전사");
        assassin = CardParsing("암살자");
        nun = CardParsing("사제");
        blackmagician = CardParsing("흑마법사");
        druid = CardParsing("드루이드");
        banyukwang = CardParsing("반역왕");
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