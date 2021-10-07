using UnityEngine;
using System.Collections;

public class Boss5Phase3State : Boss5State {

    int startTime;
    bool phase4;

	public Boss5Phase3State(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
        oFSM.GetComponent<Boss5>().FlashCore();
        oFSM.GetComponent<Boss5>().InvokeRepeating("EnergyBall2", 0, 2.5f);
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss5>().core.GetComponent<Boss5Core>().hp <= 0)
        {
            phase4 = true;
            newState = new Boss5Phase4State(oFSM);
            oFSM.ChangeState(newState);
        }
        if ((int)Time.time >= startTime + 10)
        {
            phase4 = false;
            newState = new Boss5Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss5>().Move();
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss5>().StopCore();
        oFSM.GetComponent<Boss5>().CancelInvoke("EnergyBall2");
        oFSM.GetComponent<Boss5>().Revert();
        if (!phase4)
        {
            oFSM.GetComponent<Boss5>().ReviveBarrier();
            oFSM.GetComponent<Boss5>().RestoreHp();
        }
    }
}
