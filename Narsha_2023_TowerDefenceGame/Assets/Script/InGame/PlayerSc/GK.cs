using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GK : Monster
{
    public GameObject partical;
    
    protected override void Attack() 
    {
        if (target != null)
        {
            target.GetComponent<Player>().HP -= Deamge;
            GameObject particalClone = Instantiate(partical);
            particalClone.transform.position = target.position;
            Destroy(particalClone, 5f);
        }
    }

    protected override void AttackEnd()
    {
        fTickTime = 0f;
    }
}
