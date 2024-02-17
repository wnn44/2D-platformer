using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimations : MonoBehaviour
{
    const string NameParametrAnimation = "State";

    const int IdleState = 0;
    const int RunState = 1;
    const int JumpState = 2;
    const int AttackState = 3;

    private Animator _animation;

    private State _state
    {
        get { return (State)_animation.GetInteger(NameParametrAnimation); }
        set { _animation.SetInteger(NameParametrAnimation, (int)value); }
    }

    private void OnEnable()
    {
        PlayerMove.StateValue += SetStates;
    }

    private void OnDisable()
    {
        PlayerMove.StateValue -= SetStates;
    }

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void SetStates(int stateValue)
    {
        switch (stateValue)
        {
            case IdleState:
                _state = State.Idle;
                break;
            case RunState:
                _state = State.Run;
                break;
            case JumpState:
                _state = State.Jump;
                break;
            case AttackState:
                _state = State.Attack;
                break;
        }
    }
}

public enum State
{
    Idle,
    Run,
    Jump,
    Attack
}