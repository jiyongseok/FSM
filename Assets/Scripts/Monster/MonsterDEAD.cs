using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDEAD : MonsterFSMState {

    float time;
    public override void BeginState()
    {
        base.BeginState();
        time = 2.0f;
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();
        if (time <= 0)
            Destroy(this.gameObject);
        time -= Time.deltaTime;
    }
}
