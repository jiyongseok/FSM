using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : FSMState {

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

        Vector3 dest = _manager.Marker.transform.position;
        dest.y = 0.0f;
        Vector3 playerPos = transform.position;
        playerPos.y = 0.0f;
        if(Vector3.Distance(dest, playerPos) < 0.01f)
        {
            _manager.SetState(PlayerState.IDLE);
            return;
        }

        _manager.CC.CKMove(_manager.Marker.position, _manager.Stat);
    }

}
