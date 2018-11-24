using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimEvent : MonoBehaviour {
    GoblinFSMManager _manager;
    private void Awake()
    {
        _manager = transform.root.GetComponent<GoblinFSMManager>();
    }

    void HitCheck()
    {
        GoblinATTACK attackState = _manager.CurrentStateComponent as GoblinATTACK;
        if (null != attackState)
        {
            attackState.AttackCheck();
        }
    }
}
