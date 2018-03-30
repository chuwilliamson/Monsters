using UnityEngine;
[System.Serializable]
public class GameEventTriggerEntry : IListener
{
    public GameEventArgs Event;
    public Object Sender;
    public GameEventArgsResponse Callback;
    public string Name;
    public int EnumIndex;

    public void OnEventRaised(Object[] args)
    {
        Callback.Invoke(args);
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
