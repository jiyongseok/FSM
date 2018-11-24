using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinATTACK : GoblinFSMState
{
    public override void BeginState()
    {
        base.BeginState();
        GameLib.RotateFromTo(this.transform, _manager.PlayerTransform);
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) >= _manager.Stat.AttackRange)
        {
            _manager.SetState(GoblinState.CHASE);
            return;
        }
    }

    public void AttackCheck()
    {
        GameLib.AttackCheck(this.transform, _manager.PlayerTransform);
    }
}
