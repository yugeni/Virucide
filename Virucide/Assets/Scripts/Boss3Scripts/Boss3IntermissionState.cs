using UnityEngine;
using System.Collections;

public class Boss3IntermissionState : Boss3State {

	int startTime;

	public Boss3IntermissionState(Boss3FSM fsm)
    {
        oFSM = fsm;
    }

    public override void Enter()
    {
        startTime = (int)Time.time;
        oFSM.GetComponent<Boss3>().Revert();
    }

    public override void Execute()
    {
        if((int)Time.time >= startTime + 2)
        {
            int hp = oFSM.GetComponent<Boss3>().hp;
            int originalHp = oFSM.GetComponent<Boss3>().originalHp;
            if (hp < originalHp * 2 / 3 && hp >= originalHp / 3)
            {
                newState = new Boss3Phase2State(oFSM);
                oFSM.ChangeState(newState);
            }
            else if (hp < originalHp / 3)
            {
                newState = new Boss3Phase3State(oFSM);
                oFSM.ChangeState(newState);
            }
        }
    }

    public override void Exit()
    {

    }
}
