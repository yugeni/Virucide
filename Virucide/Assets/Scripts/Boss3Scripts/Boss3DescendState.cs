using UnityEngine;
using System.Collections;

public class Boss3DescendState : Boss3State {

	public Boss3DescendState(Boss3FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
    }

    public override void Execute()
    {
        if (oFSM.transform.position.y > oFSM.GetComponent<Boss3>().yPos)
            oFSM.transform.Translate(new Vector2(0f, -0.1f), Space.World);
        else
        {
            newState = new Boss3Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss3>().EyeColor();
    }
}
