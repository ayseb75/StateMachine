using System.Collections.Generic;

public class StateMachine<T>
{
    public IState currentState;
    private Dictionary<T, IState> states = new();

    public void RegisterState(T type, IState state)
    {
        states[type] = state;
    }

    public void SwitchState(T type)
    {
        if (currentState != null) { currentState.Exit(); }
        if(states[type] == null) { currentState = null; return; }

        currentState = states[type];
        currentState.Enter();
    }
}
