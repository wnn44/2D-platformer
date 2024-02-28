using UnityEngine;

public class IdlingState : State
{

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idling  - Enter");
    }

    public override void Exit() 
    {
        base.Exit();
        Debug.Log("Idling  - Exit");
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Idling  - Update");
    }

}
