using UnityEngine;
using System.Collections;

public class Boss1FSM : MonoBehaviour {

    Boss1State descendState = null;
    Boss1State currentState = null;

	void Start () 
    {
        descendState = new Boss1DescendState(this);
        currentState = descendState;
	}
	
	void FixedUpdate () 
    {
        currentState.Execute();
	}

    public void ChangeState(Boss1State nextState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = nextState;
        currentState.Enter();
    }
}
