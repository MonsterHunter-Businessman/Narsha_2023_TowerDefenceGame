using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player
{
    
    public GameObject partical;
    
    protected override void Attack() 
    {
        target.GetComponent<Monster>().Hp -= Deamge;
        GameObject particalClone = Instantiate(partical);
        particalClone.transform.position = target.position;
        Destroy(particalClone, 1f);
    }

    protected override void AttackEnd()
    {
        fTickTime = 0f;
    }
}
