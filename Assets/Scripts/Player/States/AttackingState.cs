
using UnityEngine;

public class AttackingState : State
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attacking  - Enter");
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Attacking  - Exit");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Attacking  - Update");
    }
}
