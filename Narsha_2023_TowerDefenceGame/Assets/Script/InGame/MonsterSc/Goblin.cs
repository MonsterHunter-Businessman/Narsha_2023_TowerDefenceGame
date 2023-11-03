using Unity.VisualScripting;
using UnityEngine;

public class Goblin : Monster
{
    public GameObject partical;
    
    protected override void Attack() 
    {
        target.GetComponent<Player>().Hp -= Deamge;
        GameObject particalClone = Instantiate(partical);
        particalClone.transform.position = target.position;
        Destroy(particalClone, 5f);
    }

    protected override void AttackEnd()
    {
        fTickTime = 0f;
    }
}
