using UnityEngine;
using System.Collections;

public class Boss2IntermissionState : Boss2State {

	int startTime;

	public Boss2IntermissionState(Boss2FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
        oFSM.GetComponent<Boss2>().Revert();
    }

    public override void Execute()
    {
        if((int)Time.time >= startTime + 2)
        {
            int hp = oFSM.GetComponent<Boss2>().hp;
            int originalHp = oFSM.GetComponent<Boss2>().originalHp;
            if(hp < originalHp/2 && hp > 0)
            {
                newState = new Boss2Phase2State(oFSM);
                oFSM.ChangeState(newState);
            }
            else if(hp <= 0)
            {
                newState = new Boss2Phase3State(oFSM);
                oFSM.ChangeState(newState);
            }
        }
    }

    public override void Exit()
    {

    }
}
