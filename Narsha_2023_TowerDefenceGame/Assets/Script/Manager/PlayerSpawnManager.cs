using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager Instance;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this; 
        } else {
            Destroy(this);
        }
    }
}
