using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostKnight : Monster
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
