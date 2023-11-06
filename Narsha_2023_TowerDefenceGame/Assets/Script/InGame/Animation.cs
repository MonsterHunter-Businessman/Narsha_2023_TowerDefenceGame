using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{

    public GameObject parent;
    public string monsterName;
    private System.Type targetType;
    public MonoBehaviour scripComponent;

    private void Start()
    {

        monsterName = parent.name;
        
        monsterName = monsterName.Replace("(Clone)", "").Replace("Monster", "");
        targetType = System.Type.GetType(monsterName);
        scripComponent = parent.GetComponent(targetType) as MonoBehaviour;
    }

    private void AnimationEvent_Attack()
    {
        scripComponent.Invoke("Attack", 0f);
    }

    private void AnimationEvent_AttackEnd()
    {
        scripComponent.Invoke("AttackEnd", 0f);
    }

}
