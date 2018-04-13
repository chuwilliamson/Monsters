using UnityEngine;


public class GameEventArgsListener : MonoBehaviour, IListener
{
    public GameEventArgs Event;
    public Object Sender;
    public GameEventArgsResponse Response;
    
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Object[] args)
    {
        if (Sender == null || Sender == args[0])
            Response.Invoke(args);
    }

    public void Subscribe()
    {
        Event.RegisterListener(this);
    }

    public void Unsubscribe()
    {
        Event.UnregisterListener(this);
    }
}
