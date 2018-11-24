using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    FSMManager _manager;
    private void Awake()
    {
        _manager = transform.root.GetComponent<FSMManager>();
    }

    void HitCheck()
    {
        PlayerATTACK attackState = _manager.CurrentStateComponent as PlayerATTACK;
        if(null != attackState)
        {
            attackState.AttackCheck();
        }
    }

}
