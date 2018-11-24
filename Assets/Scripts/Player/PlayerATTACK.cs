using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TargetCheck]
public class PlayerATTACK : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
        GameLib.RotateFromTo(this.transform, _manager.Target);
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(transform.position, _manager.Target.position) > _manager.Stat.AttackRange)
        {
            _manager.SetState(PlayerState.CHASE);
        }
    }

    public void AttackCheck()
    {
        GameLib.AttackCheck(this.transform, _manager.Target);
    }
}
