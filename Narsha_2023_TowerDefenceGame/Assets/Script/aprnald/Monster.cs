using UnityEngine;
using DG.Tweening;

public class Monster : StageManager
{

    // 길에 대한 기본 설정
    public PathType pathType = PathType.CatmullRom;
    public PathMode pathMode = PathMode.Ignore;
    public int resulution = 10;
    public Color color = Color.red;
   

    // 스테이지 전체 몬스터 길
    public Vector3[][] pathval = new Vector3[][] {

            new Vector3[] { new Vector3(9, 0, 0) },
            new Vector3[] { new Vector3(8, 6, 3) }

    };

    // 이 밑에는 전부 몬스터 관련

    // 넘겨 줘야하는거 몬스터 타입,
    // 몇 스테이지고, 몇 번째
    public int monsterType;

    public Vector3[] nPathval;

    public float[] speed;

    public int[] health;

    public float[] fireTime;

    public float[] fireRange;

    public Animation[] animations;

    public int monsterWayI;

    public int monsterWayJ;


    // 발사체 관련
    public Transform target;

    public GameObject[] bulletPrefab;

    

    private void Awake()
    {
        nPathval = pathval[monsterWayI];

        if (monsterWayI == 1) {
            
        }
    }
}


//public PathType pathsystem = PathType.CatmullRom;
//public PathMode pathmode = PathMode.Ignore;
//public int resulution = 10;
//public Color gizmoColor = Color.red;

//public Vector3[] pathval = new Vector3[0];

//public float speed;

//public int health;

//public int damage;

//public float Pokemon;

//private float lateTime = 0f;

//private float pathLength = 0f;

//public float fireCountdown = 0f;

//public float fireRate = 2f;

//private Transform towerTransform;
//private bool isAttackingTower = false;
//private float attackInterval = 5f;
//private float attackTimer = 0f;

//public Transform target;
//public GameObject bulletPrefab;
//public Transform firePoint;


//// Start is called before the first frame update
//void Start()
//{

//    for (int i = 0; i < pathval.Length - 1; i++)
//    {
//        pathLength += Vector3.Distance(pathval[i], pathval[i + 1]);
//    }

//    speed = pathLength / speed;

//    InvokeRepeating("UpdateTarget", 0f, 0.5f);

//    Invoke("Move", lateTime);

//}


//void Move()
//{

//    gameObject.SetActive(true);
//    this.transform.DOPath(pathval, speed, pathsystem, pathmode, resulution, gizmoColor)
//        .SetEase(Ease.Linear)
//        .OnComplete(() =>
//        {
//            // 이동이 완료된 후에 물체를 도착 지점으로 이동시킵니다.
//            this.transform.position = pathval[pathval.Length - 1];
//        });
//}

//void Update()
//{

//    if (target == null)
//    {
//        return;
//    }

//    if (fireCountdown <= 0f)
//    {
//        AttackTower();
//        fireCountdown = 1f / fireRate;
//    }
//    fireCountdown -= Time.deltaTime;

//}


////void OnCollisionEnter2D(Collision2D col) {
//void OnTriggerEnter2D(Collider2D col)
//{

//    Debug.Log("충돌은 하나!!!!!!");

//    if (col.gameObject.tag == "Test_Arrow")
//    {
//        Debug.Log("아프타");
//        health--;
//    }
//    else if (col.gameObject.tag == "Player_Spawn")
//    {
//        Debug.Log("들어갔당");
//        Destroy(gameObject);

//        GameObject.Find("PlayerManager").GetComponent<PlayerTXT>().score -= damage;
//    }

//    if (health <= 0)
//    {
//        Debug.Log("죽었당");
//        Destroy(gameObject);
//    }

//}


//void UpdateTarget()
//{

//    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Tower");
//    float shortestDistance = Mathf.Infinity;
//    GameObject nearestEnemy = null;


//    foreach (GameObject enemy in enemies)
//    {
//        float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
//        if (distanceToEnemy < shortestDistance)
//        {
//            shortestDistance = distanceToEnemy;
//            nearestEnemy = enemy;
//        }
//    }

//    if (nearestEnemy != null && shortestDistance <= Pokemon)
//    {
//        target = nearestEnemy.transform;
//    }
//    else
//    {
//        target = null;
//    }

//}

//void AttackTower()
//{
//    //Debug.Log("빵야");
//    GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//    Bullet bullet = bulletGo.GetComponent<Bullet>();

//    if (bullet != null)
//        bullet.Seek(target);
//}

//GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수