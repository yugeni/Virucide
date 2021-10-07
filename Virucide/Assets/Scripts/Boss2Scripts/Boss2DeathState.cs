using UnityEngine;
using System.Collections;

public class Boss2DeathState : Boss2State {

	public Boss2DeathState(Boss2FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss2>().Revert();
        oFSM.GetComponent<Boss2>().Death();
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
