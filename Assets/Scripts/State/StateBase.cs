using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter(object o = null)
    {
        
    }

    public virtual void OnStateStay()
    {
        
    }

    public virtual void OnStateExit()
    {
        
    }
}

public class StatePlaying : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        BallBase b = (BallBase)o;

        GameManager.Instance.StartGame();
    }
}

public class StateResetPosition : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetBall();
    }
}

public class StateEndGame : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetPlayers();
        GameManager.Instance.ShowMainMenu();
    }
}