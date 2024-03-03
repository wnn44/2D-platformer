
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    private readonly PlayerMove _playerMove;   
    
    

    public MovementState(IStateSwitcher stateSwitcher, PlayerMove playerMove)
    {
        StateSwitcher = stateSwitcher;
        _playerMove = playerMove;
    }

    protected CharacterView View => _playerMove.View;

    public virtual void Enter()
    {
        Debug.Log(GetType());
       // View.StartIdling();
    }

    public virtual void Exit()
    {
        //View.StopIdling();
    }

    public virtual void Update()
    {
    }
}
