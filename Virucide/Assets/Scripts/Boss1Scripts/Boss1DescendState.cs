using UnityEngine;
using System.Collections;

public class Boss1DescendState : Boss1State {

	public Boss1DescendState(Boss1FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
        if (oFSM.transform.position.y > oFSM.GetComponent<Boss1>().yPos)
            oFSM.transform.Translate(new Vector2(0f, -0.1f), Space.World);
        else
        {
            newState = new Boss1Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss1>().FireRing();
    }
}
