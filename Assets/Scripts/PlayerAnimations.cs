using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimations : MonoBehaviour
{
    const string NameParametrAnimation = "State";
    
    const int IdleState = 0;
    const int RunState = 1;
    const int JumpState = 2;

    private Animator _animation;

    private States _states
    {
        get { return (States)_animation.GetInteger(NameParametrAnimation); }
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
                _states = States.Idle;
                break;
            case RunState:
                _states = States.Run;
                break;
            case JumpState:
                _states = States.Jump;
                break;
        }
    }
}

    public enum States
    {
        Idle,
        Run,
        Jump
    }