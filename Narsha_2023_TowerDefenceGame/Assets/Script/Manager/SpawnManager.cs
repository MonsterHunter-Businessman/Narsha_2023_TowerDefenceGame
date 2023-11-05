using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : Stage
{
    private GameObject monsterSpawn;

    public List<GameObject> monsterPrefab = new List<GameObject>();

    private GameObject monsterClone;

    private List<List<Vector3>> stageMonsterSpawn = new List<List<Vector3>>();

    private int nowStage;

    private bool cheack;

    public GameObject win;

    public int monsterNum;


    // public int numIterations;
    // public List<int> monsterSpawnNum = new List<int>();
    // public List<float> monsterSpawnDelay = new List<float>();
    // public List<int> monsterType = new List<int>();
    // public List<int> monsterSpawnTrans = new List<int>();
    // public List<float> monsterMove = new List<float>();
    // public bool egg;
    // public int count;

    private void Awake()
    {
        nowStage = SceneManager.GetActiveScene().buildIndex - 3;

        if (nowStage == 0) {
            monsterNum = 23;
        } else if (nowStage == 1) {
            monsterNum = 18;
        } else if (nowStage == 2) {
            monsterNum = 20;
        } else if (nowStage == 3) {
            monsterNum = 28;
        } else if (nowStage == 4) {
            monsterNum = 30;
        } 
        cheack = true;
    }

    private void Start()
    {

        if (win.activeSelf) 
            win.SetActive(false);

        stageMonsterSpawn = new List<List<Vector3>> { 
            new List<Vector3> {new Vector3(9, 2, 0), new Vector3(9, 0, 0), new Vector3(9, -2, 0)},
            new List<Vector3> {new Vector3(9, 2, 0), new Vector3(9, 0, 0), new Vector3(5, -2, 0)},
            new List<Vector3> {new Vector3(9, -3, 0), new Vector3(9, -3, 0)},
            new List<Vector3> {new Vector3(9, 2, 0),  new Vector3(9, 0, 0)},
            new List<Vector3> {new Vector3(8, 2, 0), new Vector3(8, 2, 0), new Vector3(8, 2, 0), new Vector3(8, 0, 0), new Vector3(8, 0, 0), new Vector3(8, 0, 0), new Vector3(8, -3, 0), new Vector3(8, -3, 0), new Vector3(8, -3, 0)}
        };
    }

    private void Update()
    {

        if (monsterNum == 0 && GameManager.instance.towerHp > 0) {
            win.SetActive(true);
        }

        if (nowStage > -1 && cheack) {

            cheack = false;

            monsterSpawn = GameObject.Find("MonsterSpawn");

            StartCoroutine(SpawnMonster());
        
        }
    }

    private IEnumerator SpawnMonster()
    {

        yield return new WaitForSeconds(5f);
        
        if (nowStage == 0) {
            //12
            MonsterSpawn(0, 0, 12);

            yield return new WaitForSeconds(2f);

            MonsterSpawn(2, 0, 12);

            yield return new WaitForSeconds(3f);

            MonsterSpawn(1, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(1, 0, 12);

            yield return new WaitForSeconds(8f);
            
            MonsterSpawn(0, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(0, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(0, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);
            
            yield return new WaitForSeconds(5f);

            MonsterSpawn(1, 1, 12);

            yield return new WaitForSeconds(2f);

            MonsterSpawn(1, 1, 12);
            
            yield return new WaitForSeconds(5f);

            MonsterSpawn(0, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(0, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);
            
            
            yield return new WaitForSeconds(10f);

            MonsterSpawn(1, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(1, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(1, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(1, 0, 12);
            
            yield return new WaitForSeconds(1f);

            MonsterSpawn(1, 0, 12);

            yield return new WaitForSeconds(10f);

            MonsterSpawn(1, 1, 12);
            
            yield return new WaitForSeconds(2f);

            MonsterSpawn(1, 1, 12);
            

        } else if (nowStage == 1) {
            // 17, 14, 8
            MonsterSpawn(0, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 0, 17);

            yield return new WaitForSeconds(2f);
            
            MonsterSpawn(2, 0, 8);
            
            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(0, 0, 17);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 14);

            yield return new WaitForSeconds(5f);
            
            MonsterSpawn(2, 1, 8);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(2, 1, 8);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(2, 1, 8);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(2, 1, 8);

            yield return new WaitForSeconds(3f);
            
            
            MonsterSpawn(0, 0, 17);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 14);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(2, 0, 8);


            yield return new WaitForSeconds(5f);
            
            MonsterSpawn(1, 0, 14);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 14);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 14);



            yield return new WaitForSeconds(4f);
            
            MonsterSpawn(0, 1, 17);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 17);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(2, 1, 8);
        } else if (nowStage == 2) {
            // 11 17
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(3f);
            
            MonsterSpawn(0, 0, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 0, 11);

            yield return new WaitForSeconds(2f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(3f);
            
            MonsterSpawn(0, 3, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 3, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 3, 11);

            yield return new WaitForSeconds(3f);
            
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(5f);
            
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 0, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 17);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 0, 11);

            yield return new WaitForSeconds(2f);
            
            
            MonsterSpawn(0, 1, 11);

            yield return new WaitForSeconds(3f);
            
            MonsterSpawn(0, 3, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 3, 17);
        } else if (nowStage == 3) {
            // 14, 10
            
            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(1, 0, 10);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(1, 0, 10);

            yield return new WaitForSeconds(3f);
            
            
            MonsterSpawn(0, 1, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 10);

            yield return new WaitForSeconds(5f);
            
            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 10);

            yield return new WaitForSeconds(3f);
            
            
            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(2f);


            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 10);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 10);


            yield return new WaitForSeconds(5f);
            
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(3f);
            
            

            MonsterSpawn(0, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 10);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 10);




            yield return new WaitForSeconds(5f);
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 3, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 2, 10);
        } else if (nowStage == 4) {
            MonsterSpawn(0, 1, 18);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 18);
            
            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 18);

            yield return new WaitForSeconds(3f);
            
            
            
            MonsterSpawn(4, 3, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(4, 3, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(6, 0, 15);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(6, 0, 15);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(6, 0, 15);

            yield return new WaitForSeconds(5f);
            
            
            MonsterSpawn(7, 2, 29);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(7, 2, 29);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(7, 2, 29);

            yield return new WaitForSeconds(3f);
            
            MonsterSpawn(3, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(3, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(3, 0, 14);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(3, 0, 14);

            yield return new WaitForSeconds(10f);
            
            
            
            MonsterSpawn(6, 3, 15);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(6, 3, 15);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(5, 1, 16);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 16);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(1, 0, 16);

            yield return new WaitForSeconds(5f);
            
            
            MonsterSpawn(2, 0, 10);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(2, 0, 10);

            yield return new WaitForSeconds(1f);
            
            
            MonsterSpawn(8, 0, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(8, 0, 11);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(8, 0, 11);

            yield return new WaitForSeconds(3f);
            
            
            MonsterSpawn(0, 1, 18);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 18);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 18);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 18);

            yield return new WaitForSeconds(1f);
            
            MonsterSpawn(0, 1, 18);
        }
        
    }

/// <summary>
/// 
/// </summary>
/// <param name="spawnLocation">어디서 소환되는지 선택 ( stageMonsterSpawn 참고 ) </param>
/// <param name="monsterType">몬스터 타입 결정 0 : 고블린  1 : 골렘  2 : 고스트  3 : 거미</param>
/// <param name="street">몬스터가 이동하는 거리 ( 정확해야됨 중요 움직이는 거리 ) </param>
    private void MonsterSpawn(int spawnLocation, int monsterType, float street)
    {
        monsterSpawn.transform.position = stageMonsterSpawn[nowStage][spawnLocation];

        monsterClone = Instantiate(monsterPrefab[monsterType]);

        monsterClone.transform.position = monsterSpawn.transform.position;

        monsterClone.GetComponentInChildren<Animation>().parent = monsterClone;

        monsterClone.GetComponent<Monster>().Distance = street;

        monsterClone.GetComponent<Monster>().Move(InGameStage[nowStage][spawnLocation].ToArray());

    }
}