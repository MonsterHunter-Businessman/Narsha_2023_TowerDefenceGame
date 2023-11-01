using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Monster
{
    protected override void Attack() 
    {
        target.GetComponent<Player>().Hp -= Deamge;
    }
}
