using UnityEngine;

public class Bullet : MonoBehaviour
{

    [HideInInspector] public Transform target;

    [SerializeField] private float deamge;

    public float speed;

    public GameObject effect;


    private void FixedUpdate() 
    {
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Instantiate(effect);
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