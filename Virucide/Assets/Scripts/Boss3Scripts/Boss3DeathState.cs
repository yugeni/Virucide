using UnityEngine;
using System.Collections;

public class Boss3DeathState : Boss3State {

	public Boss3DeathState(Boss3FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss3>().DestroyIce();
        oFSM.GetComponent<Boss3>().Revert();
        oFSM.GetComponent<Boss3>().Death();
    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}
