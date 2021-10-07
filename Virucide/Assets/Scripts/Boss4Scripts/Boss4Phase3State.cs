using UnityEngine;
using System.Collections;

public class Boss4Phase3State : Boss4State {

	public Boss4Phase3State(Boss4FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        oFSM.GetComponent<Boss4>().InvokeRepeating("FlashCrack", 0.0f, 4.0f);
        oFSM.GetComponent<Boss4>().ReviveHands();
        oFSM.GetComponent<Boss4>().ShootLazer();
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss4>().hp2 <= 0)
        {
            newState = new Boss4DeathState(oFSM);
            oFSM.ChangeState(newState);
        }
        oFSM.GetComponent<Boss4>().MoveHandCentre();
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss4>().CancelInvoke("FlashCrack");
    }
}
