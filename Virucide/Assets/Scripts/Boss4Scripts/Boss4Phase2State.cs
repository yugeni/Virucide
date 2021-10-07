using UnityEngine;
using System.Collections;

public class Boss4Phase2State : Boss4State {

    int startTime;

	public Boss4Phase2State(Boss4FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
        oFSM.GetComponent<Boss4>().CrackColor();
        oFSM.GetComponent<Boss4>().InvokeRepeating("DropBone", 0, 3.5f);
    }

    public override void Execute()
    {
        if (oFSM.GetComponent<Boss4>().hp <= 0)
        {
            newState = new Boss4IntermissionState(oFSM);
            oFSM.ChangeState(newState);
        }
        if((int)Time.time >= startTime + 21)
        {
            newState = new Boss4Phase1State(oFSM);
            oFSM.ChangeState(newState);
        }
    }

    public override void Exit()
    {
        oFSM.GetComponent<Boss4>().CancelInvoke("DropBone");
        oFSM.GetComponent<Boss4>().CrackGray();
    }
}
