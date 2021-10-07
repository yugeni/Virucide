using UnityEngine;
using System.Collections;

public class Boss2FSM : MonoBehaviour {

    Boss2State descendState = null;
    Boss2State currentState = null;

    void Start()
    {
        descendState = new Boss2DescendState(this);
        currentState = descendState;
    }

    void FixedUpdate()
    {
        currentState.Execute();
    }

    public void ChangeState(Boss2State nextState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = nextState;
        currentState.Enter();
    }
}
