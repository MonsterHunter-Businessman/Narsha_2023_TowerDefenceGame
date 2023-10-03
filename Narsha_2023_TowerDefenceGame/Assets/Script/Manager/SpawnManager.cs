using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnManager : Stage
{
    // Siongletone example
    public static SpawnManager instance = null;

    private GameObject monsterSpawn;

    public GameObject[] monsterPrefab;

    private GameObject monsterClone;

    private Vector3[][] stageMonsterSpawn;

    private Monster Monster;

    private int nowStage;

    private bool cheack;

    //Example
    public float monsterHp;
    public int currentStageNo;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }

        nowStage = 0;

        cheack = true;
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

    private IEnumerator SpawnMonster()
    {

        if (nowStage == 0) {

            yield return new WaitForSeconds(3f);

            MonsterSpawn(1, 0);
        }

    }

    private void MonsterSpawn(int spawnLocation, int monsterType)
    {
        monsterSpawn.transform.position = stageMonsterSpawn[nowStage][spawnLocation];

        monsterClone = Instantiate(monsterPrefab[monsterType], monsterSpawn.transform);

        monsterClone.GetComponent<Monster>().Move();

        



        // if (nowStage == 0) {
        //     goblin.Path = oneStage[spawnLocation];
        // } else if (nowStage == 1) {
        //     goblin.Path = twoStage[spawnLocation];
        // } else if (nowStage == 2) {
        //     goblin.Path = threeStage[spawnLocation];
        // } else {
        //     Debug.Log("null Stage");
        // }

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

//public float spawnInterval = 2f; // ���� ���� (��)
//public int spawnCount = 5;       // ������ Ƚ��

//private int spawnCounter;        // ���� ������ Ƚ��

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
