public class IdlingState : MovementState
{
    public IdlingState(IStateSwitcher stateSwitcher, Player playerMove) : base(stateSwitcher, playerMove)
    {
    }
    
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
    }
}
