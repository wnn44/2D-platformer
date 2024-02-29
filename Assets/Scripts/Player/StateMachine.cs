using System.Collections.Generic;
using System.Linq;

public class StateMachine: IStateSwitcher
{
    private List<IState> _states;  
    private IState _currentState;

    private Character _character;

    public StateMachine()
    {
        _states = new List<IState>() 
        {
            new IdlingState(this, _character),
            new RunningState(this, _character),
            new JumpingState(this, _character),
            new AttackingState(this, _character),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState newState = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}
