using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Siongletone example
    public static GameManager instance = null;

    private GameObject monsterSpawn;

    private GameObject monsterPrefab;

    private GameObject monsterClone;

    private Vector3[][] stageMonsterSpawn;

    private MonsterManager monsterManager;

    private int nowStage;

    private bool cheack;

    //Example
    public float monsterHp;
    public int currentStageNo;

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

        nowStage = 0;

        cheack = true;

        monsterPrefab = Resources.Load<GameObject>("Prefab/aprnald/Monster");

    }

    private void Start()
    {
        stageMonsterSpawn = new Vector3[][] { 
            new Vector3[] {new Vector3(9, 2, 0), new Vector3(9, 0, 0), new Vector3(9, -2, 0)} 
        };
    }

    private void Update()
    {
        if (nowStage > -1 && cheack) {

            cheack = false;

            monsterSpawn = GameObject.Find("MonsterSpawn");

            StartCoroutine(SpawnMonster());
        
        }
    }

    // 와 ㅅㅂ 지금 생각해도 좋은 알고리즘 이다.

    /// <summary>
    /// 스테이지에 따라 몬스터 스폰 방식이라든지 어떤 몬스터를 소환하는지 결정하는 곳...
    /// yield return으로 몇초뒤에 생선되는지 결정
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnMonster()
    {

        if (nowStage == 0) {

            yield return new WaitForSeconds(3f);

            MonsterSpawn(1, 0);
        }

    }


    /// <summary>
    /// 몬스터 스폰을 간편하게 만들기 위하면 함수
    /// </summary>
    /// <param name="spawnLocation">각 스테이지마다 몬스터 스폰 위치 지정</param>
    /// <param name="monsterType">어떤 몬스터를 소환할지 선택하는 변수</param>
    private void MonsterSpawn(int spawnLocation, int monsterType)
    {
        monsterSpawn.transform.position = stageMonsterSpawn[nowStage][spawnLocation];

        monsterClone = Instantiate(monsterPrefab, monsterSpawn.transform);

        monsterManager = monsterClone.GetComponent<MonsterManager>();

        monsterManager.monsterWayJ = spawnLocation;

        monsterManager.monsterType = monsterType;

        monsterManager.monsterWayStage = nowStage;
    }

}

//public GameObject goblin;

//public Transform mS;

//public int stage;

//public GameObject monsterB;

//public GameObject parent;

//public int[] stageMonster = new int[] { 5, 7, 9, 10 };

//Vector3[] st1 = { new Vector3 { x = 7, y = 0, z = 0 }, new Vector3 { x = 0, y = 0, z = 0 }, new Vector3 { x = -7, y = 0, z = 0 } };

//Vector3[] st2 = { new Vector3 { x = 9, y = 0, z = 0 }, new Vector3 { x = 3, y = 0, z = 0 }, new Vector3 { x = 3, y = -1, z = 0 }, new Vector3 { x = 1, y = -1, z = 0 }, new Vector3 { x = 1, y = 0, z = 0 }, new Vector3 { x = -2, y = 0, z = 0 } };

//public float spawnInterval = 2f; // 복제 간격 (초)
//public int spawnCount = 5;       // 복제할 횟수

//private int spawnCounter;        // 현재 복제한 횟수

//void Start()
//{
//    StartCoroutine(SpawnGoblins());
//}

//private IEnumerator SpawnGoblins()
//{

//    if (stage == 1)
//    {
//        while (spawnCounter < 5)
//        {
//            monsterB = Instantiate(goblin, mS.transform);

//            monsterB.transform.parent = parent.transform;

//            monsterB.GetComponent<Monster>().pathval = new Vector3[2];
//            monsterB.GetComponent<Monster>().pathval = st1;

//            spawnCounter++;

//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }
//    else if (stage == 2)
//    {
//        while (spawnCounter < 7)
//        {
//            monsterB = Instantiate(goblin, mS.transform);

//            monsterB.transform.parent = parent.transform;

//            monsterB.GetComponent<Monster>().pathval = new Vector3[6];
//            monsterB.GetComponent<Monster>().pathval = st2;

//            spawnCounter++;

//            yield return new WaitForSeconds(spawnInterval);
//        }
//    }
//}
