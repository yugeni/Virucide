using UnityEngine;
using System.Collections;

public class Boss2DescendState : Boss2State {

	public Boss2DescendState(Boss2FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
        if (oFSM.transform.position.y > oFSM.GetComponent<Boss2>().yPos)
            oFSM.transform.Translate(new Vector2(0f, -0.1f), Space.World);
        else
        {
            newState = new Boss2Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss2>().EyeColor();
    }
}
