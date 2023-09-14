using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    public GameDataManager gameDataManager;

    public int monsterType;

    public float speed;

    public float damage;

    public float fireRange;

    public float fireTime;

    public Sprite img;

    public GameObject bulletPrefab;

    Bullet bullet;

    public ParticleSystem particl;

    public Vector3[] path;

    public Transform target;


    public void SerachPlayer(float fireRange, float fireTime)
    {
        Collider[] colls = Physics.OverlapBox(this.transform.position, new Vector3(fireRange, fireRange), this.transform.rotation);

        target = colls[0].transform;

        if (colls.Length == 0) {
            target = null;
        }

        if (colls.Length > 0) {
            for (int i = 0; i < colls.Length; i++) {
                if (colls[i].CompareTag("Player")) {
                    target = colls[i].gameObject.transform;
                    break;
                }
            }
        } else {
            target = null;
        }

        if (target  != null) {
            StartCoroutine(Attack(fireTime, target, speed, damage));
        }

    }

    IEnumerator Attack(float fireTime, Transform target, float speed, float deamge)
    {

        GameObject bulletClone = Instantiate(bulletPrefab, this.transform);
        bullet = bulletClone.GetComponent<Bullet>();
        bullet.target = target;
        bullet.speed = speed;
        bullet.deamge = deamge;

        yield return new WaitForSeconds(fireTime);
    }
}
