using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GameEventArgs : ScriptableObject
{ 
    public void Raise(params Object[] args)
    {        
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(args);
    }

    public List<GameEventArgsListener> listeners = new List<GameEventArgsListener>();

    public  void RegisterListener(GameEventArgsListener listener)
    {
        if (listeners.Contains(listener))
        {
            Debug.LogError("listener is already in list");
            return;
        }
            
        listeners.Add(listener);
    }
    public  void UnregisterListener(GameEventArgsListener listener)
    {
        if (!listeners.Contains(listener))
        {
            Debug.LogError("listener is not in list");
            return;
        }
            
        listeners.Remove(listener);
    }
}

