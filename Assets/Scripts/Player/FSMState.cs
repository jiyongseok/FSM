using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSMManager))]
public class FSMState : MonoBehaviour
{
    protected FSMManager _manager;

    private void Awake()
    {
        _manager = GetComponent<FSMManager>();    
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }

    protected virtual void Update()
    {
        if(GetType().IsDefined(typeof(TargetCheckAttribute), false))
        {
            if(_manager.Target == null)
            {
                _manager.SetState(PlayerState.IDLE);
            }
        }
    }
}
