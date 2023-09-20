using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.VisualScripting;

public class MonsterManager : Stage
{

    // 길에 대한 기본 설정
    private PathType pathType = PathType.Linear;
    private PathMode pathMode = PathMode.Ignore;
    private int resulution = 10;
    private Color color = Color.red;

    // 몬스터 종류 지정
    // 0 : 고블린
    private static int allMonsterNum = 1;

    // 이 밑에는 전부 몬스터 관련

    // 넘겨 줘야하는거 몬스터 타입

    [HideInInspector]
    public int monsterType;
    
    private Vector3[] nPathval;

    private List<float> speed;

    private List<int> health;

    private List<Sprite> changeImg;

    private List<float> fireTime;

    private List<Vector3> fireRange;

    //private List<Animation> animations;


    // monsterWayStage 현제 몇 스테이지인지
    [HideInInspector]
    public int monsterWayStage;

    // monsterWatJ 어떤 길을 가는지
    [HideInInspector]
    public int monsterWayJ;

    private SpriteRenderer thisImg;


    // 발사체 관련
    private Transform target;

    private List<Sprite> bullet;

    private List<float> bulletDemage;

    private GameObject bulletPrefab;

    private GameObject aClone;

    private Bullet bul;

    private int stageNo;

    private void Awake()
    {

        bulletPrefab = Resources.Load<GameObject>("Prefab/aprnald/Attack");



        // 자기 이미지 가져오기
        thisImg = GetComponent<SpriteRenderer>();

        // 간단한 몬스터들 세팅

        // 고블린
        speed.Add(2f);

        health.Add(35);

        changeImg.Add(Resources.Load<Sprite>("IMG/aprnald/goblin"));

        fireTime.Add(3f);

        fireRange.Add(new Vector3(3, 3, 3));

        bullet.Add(Resources.Load<Sprite>("Prefab/aprnald/sword"));

        bulletDemage.Add(3f);



    }

    private void Start()
    {
        GameManager.instance.monsterHp = 100f;
        stageNo = GameManager.instance.currentStageNo;


        Debug.Log($"stage no = {stageNo}");

        thisImg.sprite = changeImg[monsterType];

        if (monsterWayStage == 0) {
            nPathval = new Vector3[6];
            nPathval = oneStage[monsterWayJ];
        }

        Move();
    }

    private void Update()
    {
        if (target != null) {
            InvokeRepeating("Attack", 0f, fireTime[monsterType]);
        }
    }

    private void FixedUpdate()
    {
        SearchPlayer();
    }

    /// <summary>
    /// Move는 DoPath를 이용해서 이동시키는 코드 입니다
    /// </summary>
    private void Move()
    {

        // nPathval : 이 오브젝트 이동할 경로
        // speed : 이 구간을 통과할 시간
        // pathType : 경로 유형 (Linear : 직선 이동, CatmullRom : 곡선 이동, CubicBezier : 각 웨이브 포인트당 2개의 제어점이 있는 곡선 이동)
        // pathMode : LookAt 옵션을 결정하는 경로 모드 (Ignore : LookAt 옵션 무시함, 3D, side-scroller 2D, top-down 2D)
        // resulution : 경로의 해상도 해상도가 높을 수록 곡선 경로가 세밀해지지만 비용이 많이 듬
        // color : 경로의 색상

        // SetEase 이동 방법 선택 (Linear 일정한 속도로 이동, InSine 시작할때 속도 감소, OutSine 끝부분에서 속도 감소, InOutSine 시작, 끝부분 속도 감소)

        this.transform.DOPath(nPathval, speed[monsterType], pathType, pathMode, resulution, color)
            .SetEase(Ease.Linear);
    }


    private void SearchPlayer()
    {
        Collider[] colls = Physics.OverlapBox(this.transform.position, fireRange[monsterType], this.transform.rotation);

        if (colls.Length == 0) {
            target = null;
        }

        target = colls[0].transform;
    }

    private void Attack()
    {
        aClone = Instantiate(bulletPrefab, this.transform);
        bul = aClone.GetComponent<Bullet>();
        bul.target = target;
        bul.speed = speed[monsterType];
        bul.deamge = bulletDemage[monsterType];
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