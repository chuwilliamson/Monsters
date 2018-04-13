using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IListener
{
    void OnEventRaised(Object[] args);
    void Subscribe();
    void Unsubscribe();
}
[CreateAssetMenu]
public class GameEventArgs : ScriptableObject
{
    public void Raise()
    {
        Raise(null);
    }
    public void Raise(params Object[] args)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(args);
    }

    public List<IListener> listeners = new List<IListener>();

    public void RegisterListener(IListener listener)
    {
        if (listeners.Contains(listener))
        {
            Debug.LogError("listener is already in list");
            return;
        }

        listeners.Add(listener);
    }
    public void UnregisterListener(IListener listener)
    {
        if (!listeners.Contains(listener))
        {
            Debug.LogError("listener is not in list");
            return;
        }

        listeners.Remove(listener);
    }
}

