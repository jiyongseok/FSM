using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterFSMManager))]
public class MonsterFSMState : MonoBehaviour
{

    protected MonsterFSMManager _manager;

    private void Awake()
    {
        _manager = GetComponent<MonsterFSMManager>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }

    protected virtual void Update()
    {
        if (GetType().IsDefined(typeof(TargetCheckAttribute), false))
        {
            if (_manager.PlayerTransform == null)
            {
                _manager.SetState(MonsterState.IDLE);
            }
        }
    }
}
