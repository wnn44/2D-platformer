
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    private readonly Character _character;
    protected Vector3 Velocity;
    protected CharacterView View => _character.View;

    public MovementState(IStateSwitcher stateSwitcher, Character character)
    {
        StateSwitcher = stateSwitcher;
        _character = character;
    }

    public virtual void Enter()
    {
        Debug.Log(GetType());
    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {



    }
}
