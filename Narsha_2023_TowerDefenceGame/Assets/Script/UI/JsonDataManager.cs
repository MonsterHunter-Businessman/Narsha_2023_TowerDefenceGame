using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDataManager : MonoBehaviour
{
    private static JsonDataManager instance = null;

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

    public class Support
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

    public class UserInfo
    {
        public string Id; //���� id
        public string Pwd; //���� ��й�ȣ
        public string Name; //���� �г���
        public string Info; //���� �ڱ�Ұ�


        public UserInfo(string Id, string Pwd, string Name, string Info)
        {
            this.Id = Id;
            this.Pwd = Pwd;
            this.Name = Name;
            this.Info = Info;
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

    public class UserInfos
    {
        public List<UserInfo> UserInfo;
    }

    public EnemyDatas enemyData;
    public CardDatas cardData;
    public SupportDatas supportData;
    public UserInfos userInfos;


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

        /*TextAsset textAsset = Resources.Load<TextAsset>("Json/EnemyData");
        Debug.Log(textAsset);
        EnemyDatas enemyData = JsonUtility.FromJson<EnemyDatas>(textAsset.text);
        Debug.Log(enemyData.Enemy);

        *//*textAsset = Resources.Load<TextAsset>("Json/ksi/CardData");
        towerData = JsonUtility.FromJson<CardDatas>(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Json/ksi/SupportData");
        supportData = JsonUtility.FromJson<SupportDatas>(textAsset.text);*/

        /* textAsset = Resources.Load<TextAsset>("Json/ksi/UserInfoData");
        userInfos = JsonUtility.FromJson<UserInfos>(textAsset.text);*//*


        Enemy enemy = MonsterParsing("Goblin");

        Debug.Log("json pasing - Enemy(Goblin) : " + enemy.tag);*/


    }

    public void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Json/EnemyData");
        Debug.Log(textAsset);
        enemyData = JsonUtility.FromJson<EnemyDatas>(textAsset.text);
        Debug.Log(enemyData.Enemy);
        Enemy enemy = MonsterParsing("Goblin");

        Debug.Log("json pasing - Enemy(Goblin) : " + enemy.tag);

        textAsset = Resources.Load<TextAsset>("Json/CardData");
        Debug.Log(textAsset);
        cardData = JsonUtility.FromJson<CardDatas>(textAsset.text);
        Debug.Log(cardData.Card);
        Card card = CardParsing("â��");

        Debug.Log("json pasing - Card(â��) : " + card.Name);
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
    public UserInfo UserParsing(string id)
    {
        UserInfo user1 = new UserInfo("", "", "", "");
        foreach (UserInfo user in userInfos.UserInfo)
        {

            if (user.Id == id)
            {
                user1 = user;
                break;
            }
        }
        return user1;
    }
}