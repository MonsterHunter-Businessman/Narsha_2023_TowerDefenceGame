using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Monster"))
        {
            GameManager.instance.towerHp -= 5;
        }
    }
}