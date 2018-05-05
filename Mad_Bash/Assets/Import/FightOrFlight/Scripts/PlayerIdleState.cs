using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerContext _playerContext;

    public void OnEnter(IContext context)
    {
        _playerContext = context as PlayerContext;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("Submit") && _playerContext.PlayerObjectBehaviour.CurrentInteractable != null)
        {
            //interact
            context.ChangeState(new PlayerInteractState());
        }
        if (Input.GetButtonDown("Cancel"))
        {
            //pause game
            context.ChangeState(new PlayerPausedState());
        }
    }

    public void OnExit(IContext context)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}