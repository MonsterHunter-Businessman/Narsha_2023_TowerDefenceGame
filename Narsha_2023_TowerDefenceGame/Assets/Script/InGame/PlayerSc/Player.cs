using Unity.VisualScripting;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    protected abstract void Attack();

    Animator animator;

    private Vector2 StartPostion;

    private Vector2 targetPostion;

    private Vector3 mPosition;

    private BoxCollider2D boxCollider2D;

    private bool Draw;

    private float fTickTime;
    


    public float Hp;

    public float Deamge;

    public Vector3 FireRange;

    Vector3 Range;

    public float FireTime;

    public Transform target;

    bool attacktrue;

    

    private void Start() 
    {
        Draw = false;

        animator = this.gameObject.GetComponent<Animator>();

        StartPostion = this.gameObject.transform.position;

        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();

        Range = FireRange + new Vector3(-0.6f, -0.6f, -0.6f);

        fTickTime = FireTime;

        attacktrue = false;

    }

    public void FixedUpdate() 
    {

        SearchMonster();

        if (Hp <= 0) {
            Destroy(this.gameObject);
        }

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void SearchMonster() 
    {
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        float closeDistance = Mathf.Infinity;
        GameObject nearbyObject = null;

        foreach (GameObject Monster in Monsters) {
            float distanceToPlayer = Vector2.Distance(transform.position, Monster.transform.position);
            if (distanceToPlayer < closeDistance) {
                closeDistance = distanceToPlayer;
                nearbyObject = Monster;
            }
        }

        if (nearbyObject != null && closeDistance <= FireRange.x) {
            if (fTickTime >= FireTime) {
                animator.SetBool("Attack", true);
                target = nearbyObject.transform;
                Attack();
                fTickTime = 0f;
            } else {
                fTickTime += Time.fixedDeltaTime;
            }
        } else {
            animator.SetBool("Attack", false);
            target = null;
        }
    }

    public void OnMouseDrag() 
    {

        Draw = true;

        boxCollider2D.offset = new Vector2(0.2f, 0f);

        boxCollider2D.size = new Vector2(5f, 5f);

        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    public void OnMouseUp() 
    {

        Draw = false;

        boxCollider2D.offset = new Vector2(0.2f, 0f);

        boxCollider2D.size = new Vector2(5f, 8f);

        transform.position = targetPostion;

        if (attacktrue) {
            FireRange = Range;
        }
    }

    private void OnMouseDown() 
    {
        FireRange = new Vector3(0, 0, 0);
    }

    public void OnDrawGizmos() 
    {

        if (Draw) {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.transform.position, FireRange + new Vector3(0.6f, 0.6f, 0.6f));
        }
    }

    public void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("DropArea")) {
            attacktrue = true;
            targetPostion = other.transform.position;
        } else {
            attacktrue = false;
            targetPostion = StartPostion;
        }
    }   
}