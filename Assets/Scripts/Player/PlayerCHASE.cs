using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TargetCheck]
public class PlayerCHASE : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();

        Vector3 dest = _manager.Target.transform.position;
        dest.y = 0.0f;
        Vector3 playerPos = transform.position;
        playerPos.y = 0.0f;
        if (Vector3.Distance(dest, playerPos) < _manager.Stat.AttackRange)
        {
            _manager.SetState(PlayerState.ATTACK);
            return;
        }

        _manager.CC.CKMove(_manager.Target.position, _manager.Stat);
    }

}
