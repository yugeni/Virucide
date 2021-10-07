using UnityEngine;
using System.Collections;

public class Boss1Phase1State : Boss1State {

    public Boss1Phase1State(Boss1FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss1>().ChangeColor();
        oFSM.GetComponent<Boss1>().ShootFireBallsO1();
    }

    public override void Execute()
    {
        if(oFSM.GetComponent<Boss1>().hp < oFSM.GetComponent<Boss1>().originalHp*2/3)
        {
            newState = new Boss1IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss1>().Move1();
    }

    public override void Exit()
    {

    }
}
