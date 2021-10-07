using UnityEngine;
using System.Collections;

public class Boss5Phase2State : Boss5State {

	public Boss5Phase2State(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss5>().HeadColor();
        oFSM.GetComponent<Boss5>().InvokeRepeating("EnergyBall1B", 0, 1.5f);
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss5>().hp <= 0)
        {
            newState = new Boss5IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss5>().Move();
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss5>().HeadGray();
        oFSM.GetComponent<Boss5>().CancelInvoke("EnergyBall1B");
        oFSM.GetComponent<Boss5>().Revert();
    }
}
