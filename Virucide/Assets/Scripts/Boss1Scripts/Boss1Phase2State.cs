using UnityEngine;
using System.Collections;

public class Boss1Phase2State : Boss1State {

	 public Boss1Phase2State(Boss1FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss1>().ChangeColor();
        oFSM.GetComponent<Boss1>().ShootFireBallsO2();
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss1>().hp < oFSM.GetComponent<Boss1>().originalHp/3)
        {
            newState = new Boss1IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss1>().Move1();
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss1>().DestroyMinions();
    }
}
