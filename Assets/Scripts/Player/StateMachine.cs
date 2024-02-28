using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;

public class StateMachine 
{
    private List<State> _states;  
    private State _currentState;

    public void Initialize()
    {
        _states = new List<State>() 
        {
            new IdlingState(),
            new RunningState(),
            new JumpingState(),
            new AttackingState(),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : global::State
    {
        global::State newState = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
