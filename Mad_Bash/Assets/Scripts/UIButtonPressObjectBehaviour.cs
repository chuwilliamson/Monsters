using UnityEngine;
using UnityEngine.Events;

public class UIButtonPressObjectBehaviour : MonoBehaviour, IContextEventHandler
{
    [SerializeField] private ButtonPressContext _buttonPressContext;
    [SerializeField] private ButtonPressObject _buttonState;

    public RectTransform OverlayTransform;
    public RectTransform ButtonTransform;

    public void onContextChanged(Object[] args)
    { 
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == _buttonState)
            ContextChangedResponse.Invoke();
      
    }

    public void onContextFinished(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == _buttonState)
            ContextFinishedResponse.Invoke();
    }

    public void onContextTimerEnd(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == _buttonState)
            ContextTimerEndResponse.Invoke();
    }

    public void onContextTimerStart(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == _buttonState)
            ContextTimerStartResponse.Invoke();
    }

    public Vector3 Startscale;
    public Vector3 NewScale;
    public float ttp;
    public float Time;
    private void Start()
    {
        ttp = _buttonState.TTP;
        StartResponse.Invoke();
        Startscale = OverlayTransform.localScale;
    }

    void Update()
    {
        this.Time =_buttonState.TimeToPress.Value / _buttonState.TTP;
        OverlayTransform.localScale = Vector3.Lerp(Startscale , Startscale * 2, Time );
    }

    [ContextMenu("Set Contexts")]
    public void SetContext()
    {
        var listeners = GetComponents<GameEventArgsListener>();
        foreach (var l in listeners)
            l.Sender = _buttonPressContext;
    }

    public UnityEvent ContextChangedResponse;
    public UnityEvent ContextFinishedResponse;
    public UnityEvent ContextTimerEndResponse;
    public UnityEvent ContextTimerStartResponse;
    public UnityEvent StartResponse;

}