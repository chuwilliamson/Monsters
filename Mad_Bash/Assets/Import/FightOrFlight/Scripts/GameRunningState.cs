using UnityEngine;

public class GameRunningState : IState
{
    public void OnEnter(IContext context)
    {
        Debug.Log("enter " + ToString());
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GamePausedState());
        if (((GameContext) context).PauseButtonClicked)
            context.ChangeState(new GamePausedState());
    }

    public void OnExit(IContext context)
    {
    }
}