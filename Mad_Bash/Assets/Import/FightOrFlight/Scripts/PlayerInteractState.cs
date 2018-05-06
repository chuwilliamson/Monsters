using UnityEngine;

public class PlayerInteractState : IState, IListener
{
    private PlayerContext _playerContext;
    private bool _finished;
    private GameEventArgs _interactionEnd;

    public void OnEventRaised(Object[] args)
    {
        _finished = true;
    }

    public void Subscribe()
    {
        _interactionEnd.RegisterListener(listener: this);
    }

    public void Unsubscribe()
    {
        _interactionEnd.UnregisterListener(listener: this);
    }

    public void OnEnter(IContext context)
    {
        // Debug.Log("Enter" + GetType().Name);
        _playerContext = context as PlayerContext;
        _interactionEnd = Resources.Load<GameEventArgs>("ScriptableObjects/Events/InteractionEnd");
        Subscribe();
        _playerContext.CharacterMovement.Disable(sender: this);

    }


    public void UpdateState(IContext context)
    {
        //we subscribe to the event to determine if we should change to the next state
        //because we do not poll input nor do we care
        if (_finished)
            context.ChangeState(new PlayerIdleState());
    }

    public void OnExit(IContext context)
    {
        //  Debug.Log("Exit" + GetType().Name);
        Unsubscribe();
        _finished = false;
        _playerContext.CharacterMovement.Enable(sender: this);
    }
}