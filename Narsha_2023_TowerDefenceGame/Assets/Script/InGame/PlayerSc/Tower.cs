using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public TextMeshProUGUI score;

    public GameObject Lose;

    public int monsterType;

    public int towerHp = 20;

    private void Start() 
    {
        if (Lose.activeSelf) {
            Lose.SetActive(false);
        }

        score.text = "타워 체력 : " + towerHp;
    }

    private void FixedUpdate() 
    {
        if (towerHp <= 0) {
            Lose.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Monster")) {
            towerHp -= 5;
            score.text = "타워 체력 : " + towerHp;
        }
    }
}