using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Player
{
    protected override void Attack() 
    {
        target.GetComponent<Player>().Hp -= Deamge;
    }
}
