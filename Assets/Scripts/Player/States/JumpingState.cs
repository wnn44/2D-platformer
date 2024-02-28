using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : State
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Jumping  - Enter");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Jumping  - Exit");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Jumping  - Update");
    }
}
