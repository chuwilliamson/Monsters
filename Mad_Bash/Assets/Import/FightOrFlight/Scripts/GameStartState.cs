using System;
using UnityEngine;

public class GameStartState : IState
{
    public void OnEnter(IContext context)
    {
        throw new NotImplementedException();
    }

    public void OnExit(IContext context)
    {
        throw new NotImplementedException();
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GameRunningState());
        if (((GameContext) context).PauseButtonClicked)
            context.ChangeState(new GamePausedState());
    }
}