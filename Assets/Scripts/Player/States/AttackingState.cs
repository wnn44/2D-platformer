using UnityEngine;

public class AttackingState : MovementState
{
    public AttackingState(IStateSwitcher stateSwitcher, Player playerMove) : base(stateSwitcher, playerMove)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartAttacking();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopAttacking();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetButtonDown(KeyAttack) == false)
            StateSwitcher.SwitchState<IdlingState>();
    }
}
