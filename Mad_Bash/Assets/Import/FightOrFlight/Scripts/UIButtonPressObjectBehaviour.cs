using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    public Vector3 Endscale;
    public Vector3 NewScale;

    public float Ttp;
    public float frac;

    private void Start()
    {
        Ttp = _buttonState.TTP;
        StartResponse.Invoke();
        Startscale = Vector3.one *  (_buttonState.TTL + _buttonState.PressBufferMax)/_buttonState.TTL;
        Endscale  = Vector3.one * .7f;
    }

    void Update()
    {
        this.frac = _buttonState.TimeToLive.Value / _buttonState.TTL;
        OverlayTransform.localScale = Vector3.Lerp(Startscale ,Endscale , 1-frac );
        
        OverlayTransform.GetComponent<Image>().color = (_buttonState.ShouldPress.Value == "yes") ? new Color(0,1,0,.25f) : new Color(1,0,0, .25f);

    }

    public void OnButtonSuccess()
    {
       
        StartCoroutine(TweenScale(.25f));
    }

    IEnumerator TweenScale(float time)
    {
        Debug.Log("yea");
        var go = Instantiate(OverlayTransform.gameObject,transform);
        var currTime = 0.0f;
        var start = OverlayTransform.localScale;
        var end = Vector3.one * 1.5f;
        while (currTime < time)
        {
            var f = currTime / time;
            go.transform.localScale = Vector3.Lerp(start, end,  f);
            currTime += Time.deltaTime;
            yield return null;
        }
        Destroy(go);
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