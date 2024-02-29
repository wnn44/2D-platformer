using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class StateMachine 
{
    private List<IState> _states;  
    private IState _currentState;

    private Character _character;

    public StateMachine()
    {
        _states = new List<IState>() 
        {
            new IdlingState(_character),
            new RunningState(_character),
            new JumpingState(_character),
            new AttackingState(_character),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : global::IState
    {
        global::IState newState = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
