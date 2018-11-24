using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimEvent : MonoBehaviour
{
    MonsterFSMManager _manager;
    private void Awake()
    {
        _manager = transform.root.GetComponent<MonsterFSMManager>();
    }

    void HitCheck()
    {
        MonsterATTACK attackState = _manager.CurrentStateComponent as MonsterATTACK;
        if (null != attackState)
        {
            attackState.AttackCheck();
        }
    }
}
