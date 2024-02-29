using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovementState
{
    public RunningState(Character character) : base(character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Running  - Enter");
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("Running  - Exit");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("Running  - Update");
    }
}
