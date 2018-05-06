using UnityEngine;


public class GameEventArgsListener : MonoBehaviour, IListener
{
    public GameEventArgs Event;
    public Object Sender;
    public GameEventArgsResponse Response;
    [TextArea(3,5)]
    public string Notes;
    
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public virtual void OnEventRaised(Object[] args)
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
