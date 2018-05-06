using UnityEngine;

public class PlayerPausedState : IState
{
    private PlayerContext _playerContext;
    private float _oldTimeScale;
    
    public void OnEnter(IContext context)
    {
        var playerPausedEnter = Resources.Load<GameEventArgs>("ScriptableObjects/Events/PlayerPausedEnter");
        playerPausedEnter.Raise(null);
        _playerContext = context as PlayerContext;
        _oldTimeScale = Time.timeScale;
        //store time

        //pause time
        Time.timeScale = 0;
        //hide cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //lock cursor

        //disableplayermovement
        _playerContext.CharacterMovement.Disable(sender:this);
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("Cancel"))
            context.ChangeState(new PlayerIdleState());
    }

    public void OnExit(IContext context)
    {
        var playerPausedExit = Resources.Load<GameEventArgs>("ScriptableObjects/Events/PlayerPausedExit");
        playerPausedExit.Raise(null);
        Time.timeScale = _oldTimeScale;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerContext.CharacterMovement.Enable(this);
    }
}