using UnityEngine;
using System.Collections;

public class Boss2Phase2State : Boss2State {

	public Boss2Phase2State(Boss2FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss2>().EyeColor();
        oFSM.GetComponent<Boss2>().ShootProjectiles();
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss2>().hp <= 0)
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
