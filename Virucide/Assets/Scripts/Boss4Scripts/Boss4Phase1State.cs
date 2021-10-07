using UnityEngine;
using System.Collections;

public class Boss4Phase1State : Boss4State {

	public Boss4Phase1State(Boss4FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss4>().ReviveHands();
        oFSM.GetComponent<Boss4>().HandBall();
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss4>().Hand1.GetComponent<Boss4Hand>().hp <= 0 && oFSM.GetComponent<Boss4>().Hand2.GetComponent<Boss4Hand>().hp <= 0)
        {
            newState = new Boss4IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {

    }
}
