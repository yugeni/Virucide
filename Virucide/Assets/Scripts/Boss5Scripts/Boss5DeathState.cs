using UnityEngine;
using System.Collections;

public class Boss5DeathState : Boss5State {

	public Boss5DeathState(Boss5FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss5>().Death();
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
    }
}
