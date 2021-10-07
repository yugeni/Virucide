using UnityEngine;
using System.Collections;

public class Boss5Phase4State : Boss5State {

	public Boss5Phase4State(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss5>().Invoke("ReleaseBall", 3.0f);
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss5>().defeated == true)
        {
            newState = new Boss5DeathState(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
    }
}
