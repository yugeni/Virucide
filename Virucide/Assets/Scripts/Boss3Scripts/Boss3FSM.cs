using UnityEngine;
using System.Collections;

public class Boss3FSM : MonoBehaviour {

    Boss3State descendState = null;
    Boss3State currentState = null;

    void Start()
    {
        descendState = new Boss3DescendState(this);
        currentState = descendState;
    }

    void FixedUpdate()
    {
        currentState.Execute();
    }

    public void ChangeState(Boss3State nextState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = nextState;
        currentState.Enter();
    }
}
