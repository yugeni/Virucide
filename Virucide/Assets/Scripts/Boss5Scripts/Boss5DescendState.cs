using UnityEngine;
using System.Collections;

public class Boss5DescendState : Boss5State {

	public Boss5DescendState(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
        if (oFSM.transform.position.y > oFSM.GetComponent<Boss5>().yPos)
            oFSM.transform.Translate(new Vector2(0f, -0.1f), Space.World);
        else
        {
            newState = new Boss5Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
    }
}
