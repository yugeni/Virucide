using UnityEngine;
using System.Collections;

public class Boss1Phase3State : Boss1State {


	public Boss1Phase3State(Boss1FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss1>().ChangeColor();
    }

    public override void Execute()
    {
        if(oFSM.GetComponent<Boss1>().hp <= 0)
        {
            newState = new Boss1DeathState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss1>().Bounce();
    }

    public override void Exit()
    {

    }
}
