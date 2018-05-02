using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerContext _playerContext;

    public void OnEnter(IContext context)
    {
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
    }

    public void OnExit(IContext context)
    {
        Debug.Log("Exit" + GetType().Name);
    }
}