using UnityEngine;
using System.Collections;

public class Boss1DeathState : Boss1State {

	 public Boss1DeathState(Boss1FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss1>().Revert();
        oFSM.GetComponent<Boss1>().Death();
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
