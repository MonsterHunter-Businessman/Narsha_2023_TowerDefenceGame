using UnityEngine;

public class Goblin : Monster
{
    
    protected override void Attack() 
    {
        target.GetComponent<Player>().Hp -= Deamge;
    }
}
