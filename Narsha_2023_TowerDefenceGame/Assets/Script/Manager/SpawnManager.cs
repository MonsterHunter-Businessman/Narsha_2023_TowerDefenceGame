using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        nowStage = 0;

        cheack = true;
    }

    private void Start()
    {

        if (win.activeSelf) {
            win.SetActive(false);
        }

        stageMonsterSpawn = new List<List<Vector3>> { 
            new List<Vector3> {new Vector3(9, 2, 0), new Vector3(9, 0, 0), new Vector3(9, -2, 0)} 
        };
    }

    private void Update()
    {

        if (monsterNum == 0 && GameObject.Find("Tower").GetComponent<Tower>().towerHp > 0) {
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

        if (nowStage == 0) {

            yield return new WaitForSeconds(3f);

            MonsterSpawn(1, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(0, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);

            yield return new WaitForSeconds(1f);

            MonsterSpawn(2, 0, 12);


        }
    }

/// <summary>
/// 
/// </summary>
/// <param name="spawnLocation">어디서 소환되는지 선택 ( stageMonsterSpawn 참고 ) </param>
/// <param name="monsterType">몬스터 타입 결정 0 : 고블린 </param>
/// <param name="street">몬스터가 이동하는 거리 ( 정확해야됨 중요 움직이는 거리 ) </param>
    private void MonsterSpawn(int spawnLocation, int monsterType, float street)
    {
        monsterSpawn.transform.position = stageMonsterSpawn[nowStage][spawnLocation];

        monsterClone = Instantiate(monsterPrefab[monsterType]);

        monsterClone.transform.position = monsterSpawn.transform.position;

        monsterClone.GetComponent<Monster>().Distance = street;

        monsterClone.GetComponent<Monster>().Move(InGameStage[nowStage][spawnLocation].ToArray());

    }
}