using UnityEngine;
using DG.Tweening;
using System;

public abstract class Monster : Stage
{

    protected abstract void Attack();
    private Color red = Color.red;

    [HideInInspector] public Transform target;

    private float fTickTime= 2f;

    [HideInInspector] public float Distance;



    public int MonsterType;
    
    public float Speed;

    public float Hp;

    public float FireTime;

    public float Deamge;

    public Vector3 FireRange;

    public void Start() 
    {
        fTickTime = FireTime;
    }

    public void Move(Vector3[] Path)
    {
        this.transform.DOPath(Path, getDirections(), PathType.Linear, PathMode.Ignore, 10, red)
            .SetEase(Ease.Linear);
    }

    public void FixedUpdate() 
    {

        if (Hp <= 0) {
            Destroy(this.gameObject);
        }

        SearchPlayer();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player_Spawn")) {
            Destroy(this.gameObject);
        }
    }

    public void SearchPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float closeDistance = Mathf.Infinity;
        GameObject nearbyObject = null;

        foreach (GameObject player in players) {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closeDistance) {
                closeDistance = distanceToPlayer;
                nearbyObject = player;
            }
        }

        if (nearbyObject != null && Mathf.Abs(closeDistance) <= FireRange.x) {
            if (fTickTime >= FireTime) {
                target = nearbyObject.transform;
                Attack();
                fTickTime = 0f;
            } else {
                fTickTime += Time.fixedDeltaTime;
            }
        } else {
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
        Gizmos.DrawWireCube(this.transform.position, FireRange);
    }
}