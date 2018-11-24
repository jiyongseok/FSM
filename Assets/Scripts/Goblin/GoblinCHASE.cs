using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TargetCheck]
public class GoblinCHASE : GoblinFSMState
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
        if (!GameLib.DetectCharacter(_manager.Sight, _manager.PlayerCC))
        {
            _manager.SetState(GoblinState.IDLE);
            return;
        }

        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) < _manager.Stat.AttackRange)
        {
            _manager.SetState(GoblinState.ATTACK);
            return;
        }

        _manager.CC.CKMove(_manager.PlayerTransform.position, _manager.Stat);
    }
}
