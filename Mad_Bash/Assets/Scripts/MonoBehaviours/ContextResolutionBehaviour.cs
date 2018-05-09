using System;
using UnityEngine;
using Object = UnityEngine.Object;

[DisallowMultipleComponent]
public class ContextResolutionBehaviour : MonoBehaviour, IContextFinishedHandler, IListener
{
    public float PassingScore;

    public ButtonPressContext ButtonPressContext;

    public GameEventArgsResponse LoseResponse;

    public GameEventArgsResponse WinResponse;

    public ISubscribeable ContextFinishedEvent;

    void OnEnable()
    {
        ContextFinishedEvent = Resources.Load<GameEventArgs>("Events/OnContextFinished");
        UnityEngine.Assertions.Assert.IsNotNull(ContextFinishedEvent);
        Subscribe();
    }

    void OnDisable()
    {
        Unsubscribe();
    }

    public virtual void OnContextFinished(Object[] args)
    {
        if (ButtonPressContext.TotalScore >= PassingScore)
        {
            WinResponse.Invoke(null);
        }
        else
        {
            LoseResponse.Invoke(null);
        }
    }

    public void OnEventRaised(Object[] args)
    {
        if (args[0] != ButtonPressContext)
            return;
        OnContextFinished(args);
    }

    public void Subscribe()
    {
        ContextFinishedEvent.RegisterListener(listener: this);
    }

    public void Unsubscribe()
    {
        ContextFinishedEvent.UnregisterListener(listener: this);
    }
}