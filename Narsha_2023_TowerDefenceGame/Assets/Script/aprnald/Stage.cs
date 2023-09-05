using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Stage : MonoBehaviour
{

    public GameObject monsterPrefab;

    public Vector3[][] stageMonsterSpawn;

    public float spqwnInterval;

    public int nowStage;

    private void Start()
    {
        nowStage = -1;

        stageMonsterSpawn = new Vector3[][] { 
            new Vector3[] {new Vector3(9, 2, 0), new Vector3(9, 0, 0), new Vector3(9, -2, 0)} 
        };

        if (nowStage > -1)
            StartCoroutine(SpawnMonster());

    }

    /// <summary>
    /// ���������� ���� ���� ���� ����̶���� � ���͸� ��ȯ�ϴ��� �����ϴ� ��
    /// yield return���� ���ʵڿ� �����Ǵ��� ����
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnMonster()
    {

        if (nowStage == 0) {
            yield return new WaitForSeconds(spqwnInterval);

            GameObject mClone = Instantiate(monsterPrefab);

            Monster monster = mClone.GetComponent<Monster>();

            monster.monsterType = 1;
        }

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
