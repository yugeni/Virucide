using UnityEngine;
using System.Collections;

public class Boss4FSM : MonoBehaviour {

    Boss4State descendState = null;
    Boss4State currentState = null;

    void Start()
    {
        descendState = new Boss4DescendState(this);
        currentState = descendState;
    }

    void FixedUpdate()
    {
        currentState.Execute();
    }

    public void ChangeState(Boss4State nextState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = nextState;
        currentState.Enter();
    }
}
