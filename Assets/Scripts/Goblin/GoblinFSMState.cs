using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GoblinFSMManager))]
public class GoblinFSMState : MonoBehaviour {
    protected GoblinFSMManager _manager;

    static bool phase1;
    static bool phase2;

    private void Awake()
    {
        phase1 = false;
        phase2 = false;
        _manager = GetComponent<GoblinFSMManager>();
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
                _manager.SetState(GoblinState.IDLE);
            }
        }
    }
}
