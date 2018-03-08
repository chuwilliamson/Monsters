using UnityEngine;

public class GameEventArgsListener : MonoBehaviour
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
}
