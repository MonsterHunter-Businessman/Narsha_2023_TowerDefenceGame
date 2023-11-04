using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public abstract class Monster : Stage
{

    protected abstract void Attack();
    protected abstract void AttackEnd();
    private Color red = Color.red;

    public Transform target;

    public float fTickTime= 2f;

    [HideInInspector] public float Distance;

    public Animator animator;

    public int MonsterType;
    
    public float Speed;

    private float Hp;

    public float HP
    {
        get { return Hp; }
        set { Hp = value; }
    }
    
    public float MaxHp;

    public float FireTime;

    public float Deamge;

    public Vector3 FireRange;

    public GameObject HpBar;
    public Slider slider;

    public GameObject clone;
    
    public GameObject monsterAnimation;

    public void Start()
    {
        HP = MaxHp;
        clone = Instantiate(HpBar, gameObject.transform);
        slider = clone.transform.Find("Slider").GetComponent<Slider>();
        animator = monsterAnimation.GetComponentInChildren<Animator>();
        
        FireRange = FireRange -= new Vector3(0.4f, 0.4f, 0.4f);
    }

    public void Move(Vector3[] Path)
    {
        this.transform.DOPath(Path, getDirections(), PathType.Linear, PathMode.Ignore, 10, new Color(0f, 0f, 0f, 0f))
            .SetEase(Ease.Linear);
    }

    public void Update() 
    {
        if (Hp <= 0) {
            GameObject.Find("GameManager").GetComponent<SpawnManager>().monsterNum -= 1;
            Destroy(this.gameObject);
        }

        fTickTime += Time.deltaTime;

        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0f));
        slider.value = Hp / MaxHp;

        SearchPlayer();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player_Spawn")) {
            GameObject.Find("GameManager").GetComponent<SpawnManager>().monsterNum -= 1;
            Destroy(this.gameObject);
        }
    }

    private void SearchPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closeDistance = Mathf.Infinity;
        GameObject nearbyObject = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closeDistance)
            {
                closeDistance = distanceToPlayer;
                nearbyObject = player;
            }
        }

        if (nearbyObject != null && closeDistance <= FireRange.x)
        {
            if (fTickTime >= FireTime)
            {
                animator.SetBool("Attack", true);
                target = nearbyObject.transform;
                fTickTime = 0f;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            target = null;
        }
    }


    private float getDirections() 
    {
        return (Distance / Speed) * 10;
    }

    public void OnDrawGizmos() 
    {
        Gizmos.color = red;
        Gizmos.DrawWireCube(this.transform.position, FireRange + new Vector3(1.4f, 1.4f, 1.4f));
    }
}