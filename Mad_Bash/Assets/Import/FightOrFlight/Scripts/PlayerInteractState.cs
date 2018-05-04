using UnityEngine;

public class PlayerInteractState : IState, IListener
{
    private GameEventArgs InteractionEnd;
    private PlayerContext _playerContext;

    public void OnEnter(IContext context)
    {
       // Debug.Log("Enter" + GetType().Name);
        _playerContext = context as PlayerContext;
        InteractionEnd = Resources.Load<GameEventArgs>("ScriptableObjects/Events/InteractionEnd");
        Subscribe();
        _playerContext.PlayerController.enabled = false;
        _playerContext.PlayerController.character.CurrentSpeed.Value = 0.0f;

    }

    bool Finished = false;

    public void UpdateState(IContext context)
    {
        //we subscribe to the event to determine if we should change to the next state
        //because we do not poll input nor do we care
        if (Finished)
            context.ChangeState(new PlayerIdleState());
    }

    public void OnExit(IContext context)
    {
      //  Debug.Log("Exit" + GetType().Name);
        Unsubscribe();
        Finished = false;
        _playerContext.PlayerController.enabled = true;
    }

    public void OnEventRaised(Object[] args)
    {
        Finished = true;
    }

    public void Subscribe()
    {
        InteractionEnd.RegisterListener(this);
    }

    public void Unsubscribe()
    {
        InteractionEnd.UnregisterListener(this);
    }
}