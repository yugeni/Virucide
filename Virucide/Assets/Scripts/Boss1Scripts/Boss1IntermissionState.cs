using UnityEngine;
using System.Collections;

public class Boss1IntermissionState : Boss1State {

    int startTime;

	public Boss1IntermissionState(Boss1FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
        oFSM.GetComponent<Boss1>().Revert();
    }

    public override void Execute()
    {
        if((int)Time.time >= startTime + 2)
        {
            int hp = oFSM.GetComponent<Boss1>().hp;
            int originalHp = oFSM.GetComponent<Boss1>().originalHp;
            if(hp < originalHp*2/3 && hp >= originalHp/3)
            {
                newState = new Boss1Phase2State(oFSM);
                oFSM.ChangeState(newState);
            }
            else if(hp < originalHp/3)
            {
                newState = new Boss1Phase3State(oFSM);
                oFSM.ChangeState(newState);
            }
        }
    }

    public override void Exit()
    {

    }
}
