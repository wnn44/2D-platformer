
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MovementState : IState
{
    private readonly Character _character;
    protected Vector3 Velocity;

    public MovementState(Character character)
    {
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
