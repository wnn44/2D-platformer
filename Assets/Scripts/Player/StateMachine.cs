using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine: IStateSwitcher
{
    private List<IState> _states;  
    private IState _currentState;

    public StateMachine(PlayerMove playerMove)
    {
        _states = new List<IState>() 
        {
            new IdlingState(this, playerMove),
            new RunningState(this, playerMove),
            new JumpingState(this, playerMove),
            new AttackingState(this, playerMove),
        };

        _currentState = _states[0];        
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
