using UnityEngine;

[System.Serializable]
public class GameEventTriggerEntry : IListener
{
    public GameEventArgs Event;
    public GameEventArgsResponse Response;
    public Object Sender;
    public string Name;
    public int EventID;
    public bool RequiresSender;

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