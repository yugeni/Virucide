using UnityEngine;
using System.Collections;

public class Boss3Phase1State : Boss3State {

	public Boss3Phase1State(Boss3FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss3>().SummonIces();
        oFSM.GetComponent<Boss3>().DropIcicles1();
    }

    public override void Execute()
    {
        if(oFSM.GetComponent<Boss3>().hp < oFSM.GetComponent<Boss3>().originalHp*2/3)
        {
            newState = new Boss3IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss3>().Move();
    }

    public override void Exit()
    {

    }
}
