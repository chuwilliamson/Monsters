using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerContext _playerContext;

    public void OnEnter(IContext context)
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerContext = context as PlayerContext;
        Debug.Log("Enter" + GetType().Name);
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
            //interact
            context.ChangeState(new PlayerPausedState());
        }
    }

    public void OnExit(IContext context)
    {
        Debug.Log("Exit" + GetType().Name);
    }
}