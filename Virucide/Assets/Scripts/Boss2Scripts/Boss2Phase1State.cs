using UnityEngine;
using System.Collections;

public class Boss2Phase1State : Boss2State {

	public Boss2Phase1State(Boss2FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss2>().SummonMinions();
    }

    public override void Execute()
    {
        if(oFSM.GetComponent<Boss2>().hp < oFSM.GetComponent<Boss2>().originalHp/2)
        {
            newState = new Boss2IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss2>().Move1();
    }

    public override void Exit()
    {
    }
}
