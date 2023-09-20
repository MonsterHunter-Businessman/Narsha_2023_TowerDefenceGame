using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.VisualScripting;

public class MonsterManager : Stage
{

    // �濡 ���� �⺻ ����
    private PathType pathType = PathType.Linear;
    private PathMode pathMode = PathMode.Ignore;
    private int resulution = 10;
    private Color color = Color.red;

    // ���� ���� ����
    // 0 : ���
    private static int allMonsterNum = 1;

    // �� �ؿ��� ���� ���� ����

    // �Ѱ� ����ϴ°� ���� Ÿ��

    [HideInInspector]
    public int monsterType;
    
    private Vector3[] nPathval;

    private List<float> speed;

    private List<int> health;

    private List<Sprite> changeImg;

    private List<float> fireTime;

    private List<Vector3> fireRange;

    //private List<Animation> animations;


    // monsterWayStage ���� �� ������������
    [HideInInspector]
    public int monsterWayStage;

    // monsterWatJ � ���� ������
    [HideInInspector]
    public int monsterWayJ;

    private SpriteRenderer thisImg;


    // �߻�ü ����
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



        // �ڱ� �̹��� ��������
        thisImg = GetComponent<SpriteRenderer>();

        // ������ ���͵� ����

        // ���
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
    /// Move�� DoPath�� �̿��ؼ� �̵���Ű�� �ڵ� �Դϴ�
    /// </summary>
    private void Move()
    {

        // nPathval : �� ������Ʈ �̵��� ���
        // speed : �� ������ ����� �ð�
        // pathType : ��� ���� (Linear : ���� �̵�, CatmullRom : � �̵�, CubicBezier : �� ���̺� ����Ʈ�� 2���� �������� �ִ� � �̵�)
        // pathMode : LookAt �ɼ��� �����ϴ� ��� ��� (Ignore : LookAt �ɼ� ������, 3D, side-scroller 2D, top-down 2D)
        // resulution : ����� �ػ� �ػ󵵰� ���� ���� � ��ΰ� ������������ ����� ���� ��
        // color : ����� ����

        // SetEase �̵� ��� ���� (Linear ������ �ӵ��� �̵�, InSine �����Ҷ� �ӵ� ����, OutSine ���κп��� �ӵ� ����, InOutSine ����, ���κ� �ӵ� ����)

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
//            // �̵��� �Ϸ�� �Ŀ� ��ü�� ���� �������� �̵���ŵ�ϴ�.
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

//    Debug.Log("�浹�� �ϳ�!!!!!!");

//    if (col.gameObject.tag == "Test_Arrow")
//    {
//        Debug.Log("����Ÿ");
//        health--;
//    }
//    else if (col.gameObject.tag == "Player_Spawn")
//    {
//        Debug.Log("����");
//        Destroy(gameObject);

//        GameObject.Find("PlayerManager").GetComponent<PlayerTXT>().score -= damage;
//    }

//    if (health <= 0)
//    {
//        Debug.Log("�׾���");
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
//    //Debug.Log("����");
//    GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//    Bullet bullet = bulletGo.GetComponent<Bullet>();

//    if (bullet != null)
//        bullet.Seek(target);
//}

//GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().����