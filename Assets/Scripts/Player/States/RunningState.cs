using UnityEngine;

public class RunningState : MovementState
{
    public RunningState(IStateSwitcher stateSwitcher, Player playerMove) : base(stateSwitcher, playerMove)
    {
    }

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

        if (Input.GetAxis(AxesHorizontal) == 0)
            StateSwitcher.SwitchState<IdlingState>();
    }
}
