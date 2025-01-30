using UnityEngine;

public class JumpingState : MovementState
{
    public JumpingState(IStateSwitcher stateSwitcher, Player playerMove) : base(stateSwitcher, playerMove)
    {
    }

    public override void Enter()
    {
        base.Enter();
     
        View.StartJumping();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();
    }
}
