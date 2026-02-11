using System;
using System.Collections.Generic;

public class GameStateMachine 
{
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine()
    {
        _states = new Dictionary<Type, IState>
        {
            { typeof(MenuState), new MenuState(this) },
            { typeof(RaceState), new RaceState(this) }
        };
    }

    public void Enter<T>() where T : IState
    {
        _activeState?.Exit();
        _activeState = _states[typeof(T)];
        _activeState.Enter();
    }
}
