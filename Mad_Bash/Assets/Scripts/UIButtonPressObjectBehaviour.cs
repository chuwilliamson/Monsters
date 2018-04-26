using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIButtonPressObjectBehaviour : MonoBehaviour, IContextEventHandler
{
    [SerializeField]
    private ButtonPressObject ButtonState;
    [SerializeField]
    private ButtonPressContext ButtonPressContext;
    public UnityEvent StartResponse;

    public UnityEvent ContextChangedResponse;
    public UnityEvent ContextFinishedResponse;
    public UnityEvent ContextTimerEndResponse;
    public UnityEvent ContextTimerStartResponse;
    private void Start()
    {
        StartResponse.Invoke();
        
    }
    [ContextMenu("Set Contexts")]
    public void SetContext()
    {
        var listeners = GetComponents<GameEventArgsListener>();
        foreach (var l in listeners)
        {
            l.Sender = ButtonPressContext;
        }
        
        
    }
    public void onContextChanged(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == ButtonState)
        {
            ContextChangedResponse.Invoke();
        }
    }

    public void onContextFinished(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == ButtonState)
        {
            ContextFinishedResponse.Invoke();
        }
    }

    public void onContextTimerEnd(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == ButtonState)
        {
            ContextTimerEndResponse.Invoke();
        }
    }

    public void onContextTimerStart(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == ButtonState)
        {
            ContextTimerStartResponse.Invoke();
        }
    }
}
