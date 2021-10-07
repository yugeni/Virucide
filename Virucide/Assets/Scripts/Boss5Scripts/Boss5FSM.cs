using UnityEngine;
using System.Collections;

public class Boss5FSM : MonoBehaviour {

    Boss5State descendState = null;
    Boss5State currentState = null;

    void Start()
    {
        descendState = new Boss5DescendState(this);
        currentState = descendState;
    }

    void FixedUpdate()
    {
        currentState.Execute();
    }

    public void ChangeState(Boss5State nextState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = nextState;
        currentState.Enter();
    }
}
