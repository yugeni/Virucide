using UnityEngine;
using System.Collections;

public class Boss5Phase1State : Boss5State {

	public Boss5Phase1State(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss5>().ActivateBarrier();
        oFSM.GetComponent<Boss5>().InvokeRepeating("EnergyBall1A", 0, 0.5f);
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss5>().barrier.GetComponent<Boss5Barrier>().hp <= 0)
        {
            newState = new Boss5IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss5>().CancelInvoke("EnergyBall1A");
    }
}
