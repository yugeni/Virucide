using UnityEngine;
using System.Collections;

public class Boss4IntermissionState : Boss4State {

	int startTime;

	public Boss4IntermissionState(Boss4FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
    }

    public override void Execute()
    {
        if((int)Time.time >= startTime + 2)
        {
            int hp = oFSM.GetComponent<Boss4>().hp;
            if (hp > 0)
            {
                newState = new Boss4Phase2State(oFSM);
                oFSM.ChangeState(newState);
            }
            else if (hp <= 0)
            {
                newState = new Boss4Phase3State(oFSM);
                oFSM.ChangeState(newState);
            }
        }
    }

    public override void Exit()
    {

    }
}
