using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovementState
{
    public RunningState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher, character)
    {
    }

    const string NameAxesHorizontal = "Horizontal";

    public override void Enter()
    {
        base.Enter();
        View.StartRunning();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetAxis(NameAxesHorizontal) == 0)
            StateSwitcher.SwitchState<IdlingState>();
    }
}
