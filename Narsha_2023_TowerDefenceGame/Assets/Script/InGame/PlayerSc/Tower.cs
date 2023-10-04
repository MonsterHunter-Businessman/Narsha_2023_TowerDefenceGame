using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TextMeshProUGUI score;

    public int monsterType;

    private int towerHp = 100;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Monster")) {
            monsterType = other.GetComponent<Monster>().MonsterType;
            if (monsterType == 0) {
                towerHp -= 5;
            }

            score.text = "타워 체력 : " + towerHp;
        }
    }

}
