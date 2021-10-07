using UnityEngine;
using System.Collections;

public class Boss4DeathState : Boss4State {

	public Boss4DeathState(Boss4FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss4>().Defeat();
        oFSM.GetComponent<Boss4>().Death();
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
