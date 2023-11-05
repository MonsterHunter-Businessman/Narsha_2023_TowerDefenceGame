using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Player : MonoBehaviour
{
    protected abstract void Attack();

    protected abstract void AttackEnd();

    Animator animator;

    private Vector2 StartPostion;

    private Vector2 targetPostion;

    private Vector3 mPosition;

    private BoxCollider2D boxCollider2D;

    private bool Draw;

    public float fTickTime;
    


    private float Hp;
    public float HP
    {
        get { return Hp; }
        set { Hp = value; }
    }

    public float MaxHp;

    public float Deamge;

    public Vector3 FireRange;

    Vector3 Range;

    public float FireTime;

    public Transform target;

    bool attacktrue;
    
    public GameObject HpBar;
    public Slider slider;
    public GameObject clone;

    

    private void Start()
    {
        HP = MaxHp;
        
        Draw = false;

        animator = this.gameObject.GetComponent<Animator>();

        StartPostion = this.transform.position;

        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();

        Range = FireRange;

        fTickTime = FireTime;

        attacktrue = false;
        
        clone = Instantiate(HpBar, gameObject.transform);
        slider = clone.transform.Find("Slider").GetComponent<Slider>();

        Range = Range -= new Vector3(0.4f, 0.4f, 0.4f);

    }

    public void Update() 
    {

        SearchMonster();

        if (Hp <= 0)
            Destroy(this.gameObject);
        

        fTickTime += Time.deltaTime;

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0.18f, 0.6f, 0f));
        slider.value = Hp / MaxHp;
    }

    public void SearchMonster()
    {
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        float closeDistance = Mathf.Infinity;
        GameObject nearbyObject = null;

        foreach (GameObject Monster in Monsters)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Monster.transform.position);
            if (distanceToPlayer < closeDistance)
            {
                closeDistance = distanceToPlayer;
                nearbyObject = Monster;
            }
        }

        if (nearbyObject != null && closeDistance <= FireRange.x)
        {
            if (fTickTime >= FireTime)
            {
                animator.SetBool("Attack", true);
                target = nearbyObject.transform;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            target = null;
        }
    }

    public void OnMouseDrag() 
    {

        Draw = true;

        boxCollider2D.offset = new Vector2(2.5f, 0f);

        boxCollider2D.size = new Vector2(5f, 5f);

        gameObject.transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    public void OnMouseUp() 
    {

        //Draw = false;

        boxCollider2D.offset = new Vector2(2.5f, 0f);

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
            Gizmos.DrawWireCube(this.transform.position, FireRange + new Vector3(1.4f, 1.4f, 1.4f));
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