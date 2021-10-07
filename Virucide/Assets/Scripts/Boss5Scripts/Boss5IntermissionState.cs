using UnityEngine;
using System.Collections;

public class Boss5IntermissionState : Boss5State {

    int startTime;

	public Boss5IntermissionState(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
    }

    public override void Execute()
    {
        if ((int)Time.time >= startTime + 2)
        {
            int hp = oFSM.GetComponent<Boss5>().hp;
            if (hp > 0)
            {
                newState = new Boss5Phase2State(oFSM);
                oFSM.ChangeState(newState);
            }
            else if (hp <= 0)
            {
                newState = new Boss5Phase3State(oFSM);
                oFSM.ChangeState(newState);
            }
        }
    }

    public override void Exit()
    {

    }
}
