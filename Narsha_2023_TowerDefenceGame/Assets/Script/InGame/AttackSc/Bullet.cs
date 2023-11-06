using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Transform target;

    [SerializeField] private float deamge;

    public float speed;

    private Vector3 dir;

    public GameObject effect;

    private void Start()
    {
        dir = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }


    private void FixedUpdate() 
    {
        dir = (target.position - transform.position).normalized;
        transform.Translate(dir * (speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            GameObject clone = Instantiate(effect);
            clone.transform.position = transform.position;
            other.GetComponent<Player>().HP -= deamge;
            Destroy(this.gameObject);
        } 
    }


    // private  IEnumerator Attack()
    // {
    //     aClone = Instantiate(Bullet, this.transform);
    //     bul = aClone.GetComponent<Bullet>();
    //     bul.target = target;
    //     yield return new WaitForSeconds(FireTime);
    // }


}