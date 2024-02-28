
using UnityEngine;

public class Character : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize();
    }

    private void Update()
    {
        _stateMachine.Update();

        if (Input.GetKeyUp(KeyCode.R))
            _stateMachine.SwitchState<RunningState>();

        if (Input.GetKeyUp(KeyCode.I))
            _stateMachine.SwitchState<IdlingState>();

        if (Input.GetKeyUp(KeyCode.J))
            _stateMachine.SwitchState<JumpingState>();
    }
}
