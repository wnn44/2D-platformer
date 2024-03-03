
using UnityEngine;

public class AttackingState : MovementState
{
    public AttackingState(IStateSwitcher stateSwitcher, PlayerMove playerMove) : base(stateSwitcher, playerMove)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Attacking  - Enter");
        View.StartAttacking();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopAttacking();
        //Debug.Log("Attacking  - Exit");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("Attacking  - Update");
    }
}
