using UnityEngine;

public class PlayerPausedState : IState
{
    private PlayerContext _playerContext;
    float oldTimeScale;
    public void OnEnter(IContext context)
    {
        
        _playerContext = context as PlayerContext;

        oldTimeScale = Time.timeScale;
        //store time

        //pause time
        Time.timeScale = 0;
        //hide cursor
        Cursor.visible = true;
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //disableplayermovement
        _playerContext.PlayerController.enabled = false;
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("Cancel"))
        {//interact
            context.ChangeState(new PlayerIdleState());
        }
    }

    public void OnExit(IContext context)
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = oldTimeScale;
        Cursor.visible = false;
        _playerContext.PlayerController.enabled = true;
        Debug.Log("Exit" + GetType().Name);
    }
}