using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPATROL : MonsterFSMState {

    public Vector3 destination;

    public override void BeginState()
    {
        base.BeginState();

        destination = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        if (GameLib.DetectCharacter(_manager.Sight, _manager.PlayerCC))
        {
            _manager.SetState(MonsterState.CHASE);
            return;
        }

        if (Vector3.Distance(destination, transform.position) < 0.1f)
        {
            _manager.SetState(MonsterState.IDLE);
            return;
        }

        _manager.CC.CKMove(destination, _manager.Stat);

    }
}
