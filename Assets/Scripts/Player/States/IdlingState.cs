using UnityEngine;

public class IdlingState : MovementState
{
    public IdlingState(IStateSwitcher stateSwitcher, Character character) : base(stateSwitcher, character)
    {
    }

    const string NameAxesHorizontal = "Horizontal";
    
    public override void Enter()
    {
        base.Enter();
        View.StartIdling();
    }

    public override void Exit() 
    {
        base.Exit();
        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetAxis(NameAxesHorizontal) != 0)
            StateSwitcher.SwitchState<RunningState>();
    }
}
