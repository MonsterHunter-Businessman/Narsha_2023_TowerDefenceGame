using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Monster : Stage
{
    private PathType pathType = PathType.Linear;
    private PathMode pathMode = PathMode.Ignore;
    private int resulution = 10;
    private Color color = Color.red;



    private Vector3[] Path;

    private float speed;

    private Vector3 fireRange;

    private float fireTime;

    private GameObject bullet;

    
    private Transform target;
    private GameObject aClone;
    private Bullet bul;


    public float Speed;

    public float FireTime;

    public Vector3 FireRange;

    public GameObject Bullet;



    public void Move()
    {
        this.transform.DOPath(Path, Speed, pathType, pathMode, resulution, color)
            .SetEase(Ease.Linear);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
            target = other.transform;
    }

    public void SearchPlayer()
    {
        Collider[] colls = Physics.OverlapBox(this.transform.position, FireRange, this.transform.rotation);

        for (int i = 0; i < colls.Length; i++) 
            if (colls[i].CompareTag("Player")) 
                target = colls[0].transform;
        if (colls.Length == 0) 
            target = null;

        if (target != null)
            Attack(bullet, FireTime);
        
    }

    private IEnumerator Attack(GameObject BulletPrefab, float FireTime)
    {
        aClone = Instantiate(BulletPrefab, this.transform);
        bul = aClone.GetComponent<Bullet>();
        bul.target = target;
        yield return new WaitForSeconds(FireTime);
    }

}
