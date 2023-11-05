using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int towerHp;

    public TextMeshProUGUI towerHpText;

    public GameObject Lose;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        towerHpText.text = "타워 체력 : " + towerHp;

        if (towerHp <= 0)
        {
            Lose.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}