using UnityEngine;

public class Bullet : MonoBehaviour
{

    [HideInInspector] public Transform target;

    [SerializeField] private float deamge;

    public float speed;


    private void FixedUpdate() 
    {
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        if (dir.magnitude <= distanceThisFrame) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().Hp -= deamge;
        } else if (other.CompareTag("Monster")) {
            other.GetComponent<Monster>().Hp -= deamge;
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