using UnityEngine;

public class GamePausedState : IState
{
    public void OnEnter(IContext context)
    {
        Debug.Log("enter " + ToString());
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GameRunningState());
    }

    public void OnExit(IContext context)
    {
    }
}