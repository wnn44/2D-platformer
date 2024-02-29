
using UnityEngine;

public class AttackingState : MovementState
{
    public AttackingState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher, character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Attacking  - Enter");
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("Attacking  - Exit");
    }

    public override void Update()
    {
        base.Update();
        //Debug.Log("Attacking  - Update");
    }
}
