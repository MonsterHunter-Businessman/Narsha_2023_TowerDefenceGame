using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    public GameObject bullet;

    public GameObject firePint;
    
    protected override void Attack()
    {
        if (target != null)
        {
            GameObject clone = Instantiate(bullet);
            clone.transform.position = firePint.transform.position;
            clone.GetComponent<Bullet>().target = target;
        }
    }

    protected override void AttackEnd()
    {
        fTickTime = 0f;
    }
}
