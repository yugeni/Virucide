using UnityEngine;
using System.Collections;

public class Boss3Phase2State : Boss3State {

	public Boss3Phase2State(Boss3FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss3>().EyeColor();
        oFSM.GetComponent<Boss3>().SummonIces();
        oFSM.GetComponent<Boss3>().ShootLazer();
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss3>().hp < oFSM.GetComponent<Boss3>().originalHp / 3)
        {
            newState = new Boss3IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss3>().Move();
        oFSM.GetComponent<Boss3>().Move2();
    }

    public override void Exit()
    {
    }
}
