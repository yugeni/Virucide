using UnityEngine;
using System.Collections;

public class Boss3Phase3State : Boss3State {

	public Boss3Phase3State(Boss3FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss3>().EyeColor();
        oFSM.GetComponent<Boss3>().SummonIces();
        oFSM.GetComponent<Boss3>().DropIcicles2();
    }

    public override void Execute()
    {
        if(oFSM.GetComponent<Boss3>().hp <= 0)
        {
            newState = new Boss3DeathState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss3>().Move();
    }

    public override void Exit()
    {

    }
}
