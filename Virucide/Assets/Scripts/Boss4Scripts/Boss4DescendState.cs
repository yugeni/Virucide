using UnityEngine;
using System.Collections;

public class Boss4DescendState : Boss4State {

	public Boss4DescendState(Boss4FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
        if (oFSM.transform.position.y > oFSM.GetComponent<Boss4>().yPos)
            oFSM.transform.Translate(new Vector2(0f, -0.1f), Space.World);
        else
        {
            newState = new Boss4Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
    }
}
