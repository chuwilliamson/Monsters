using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButtonPressObjectBehaviour : MonoBehaviour, IContextEventHandler
{
    [SerializeField]
    private ButtonPressContext _buttonPressContext;
    [SerializeField]
    private ButtonPressObject _buttonState;

    public bool MoveInCamera;
    public RectTransform ButtonTransform;
    public float Frac;
    public float Ttp;
    public Vector3 OverlayEndscale;
    public Vector3 OverlayNewScale;
    public Vector3 OverlayStartScale;
    public RectTransform OverlayTransform;
    public GameObject UIRipplePrefab;

    public UnityEvent StartResponse;
    public UnityEvent ContextChangedResponse;
    public UnityEvent ContextFinishedResponse;
    public UnityEvent ContextTimerEndResponse;
    public UnityEvent ContextTimerStartResponse;

    

    
    #region IContextEventHandler
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
        
        if(MoveInCamera)
            gameObject.MoveInCamera(newPos: Vector3.one);
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
    #endregion  

    public void OnButtonSuccess()
    {
        if (_buttonState != _buttonPressContext.CurrentState as ButtonPressObject)
            return;
        var go = Instantiate(UIRipplePrefab, transform);
        var ripple = go.GetComponent<UIRipple>();
        ripple.CreateRipple(go.transform.localPosition);
        go.transform.SetAsLastSibling();
        Destroy(go, 3);
    }

    [ContextMenu("Set Contexts")]
    public void SetContext()
    {
        var listeners = GetComponents<GameEventArgsListener>();
        foreach (var l in listeners)
            l.Sender = _buttonPressContext;
    }

    private void Start()
    {
        Ttp = _buttonState.TTP;
        StartResponse.Invoke();
        OverlayStartScale = Vector3.one * (_buttonState.TTL + _buttonState.PressBufferMax) / _buttonState.TTL;
        OverlayEndscale = Vector3.one * .7f;
    }

    private void Update()
    {
        Frac = _buttonState.CurrentTimeToLive / _buttonState.TTL;
        OverlayTransform.localScale = Vector3.Lerp(OverlayStartScale, OverlayEndscale, 1 - Frac);

        OverlayTransform.GetComponent<Image>().color = _buttonState.ShouldPress.Value == "yes"
            ? new Color(0, 1, 0, .25f)
            : new Color(1, 0, 0, .25f);
    }

    private IEnumerator TweenScale(float time, Transform trans)
    {
        OverlayTransform.gameObject.SetActive(true);
        var currTime = 0.0f;
        var start = OverlayTransform.localScale;
        var end = Vector3.one * 1.5f;
        while (currTime < time)
        {
            var f = currTime / time;
            OverlayTransform.transform.localScale = Vector3.Lerp(start, end, f);
            currTime += Time.deltaTime;
            yield return null;
        }
        OverlayTransform.gameObject.SetActive(false);
    }
}