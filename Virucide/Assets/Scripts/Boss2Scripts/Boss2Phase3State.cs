using UnityEngine;
using System.Collections;

public class Boss2Phase3State : Boss2State {

	public Boss2Phase3State(Boss2FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss2>().FlashFeelers();
        oFSM.GetComponent<Boss2>().RandomAttack();
    }

    public override void Execute()
    {
        if(oFSM.GetComponent<Boss2>().hp2 <= 0)
        {
            newState = new Boss2DeathState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss2>().Move1();
    }

    public override void Exit()
    {

    }
}
