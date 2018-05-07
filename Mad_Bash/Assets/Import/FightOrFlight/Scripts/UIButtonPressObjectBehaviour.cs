using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[DisallowMultipleComponent]
public class UIButtonPressObjectBehaviour : MonoBehaviour, IContextEventHandler
{
    [SerializeField] private ButtonPressContext _buttonPressContext;

    [SerializeField] private ButtonPressObject _buttonState;


    [Range(0, 6)]
    public float DistanceFromCamera;
    public float Frac;

    public bool MoveInCamera;
    public GameEventArgs OnButtonGameObjectPositionChange;
    
    private Vector3 OverlayEndscale;
    
    private Vector3 OverlayStartScale;

    [ReadOnly]
    public float Ttp;
    public GameObject UIRipplePrefab;
    public RectTransform ButtonTransform;
    public RectTransform OverlayTransform;

    public UnityEvent StartResponse;
    public UnityEvent ContextChangedResponse;
    public UnityEvent ContextFinishedResponse;
    public UnityEvent ContextTimerEndResponse;
    public UnityEvent ContextTimerStartResponse;

    public void OnButtonSuccess(Object[] args)
    {
        var sender = args[0] as ButtonPressObject;
        var activecontext = args[1] as ButtonPressContext;

        if (sender == null)

            return;
        if (sender != _buttonState || activecontext  != _buttonPressContext)
            return;
        var go = Instantiate(UIRipplePrefab, transform);
        var ripple = go.GetComponent<UIRipple>();
        ripple.CreateRipple(go.transform.localPosition);
        go.transform.SetAsLastSibling();
        Destroy(go, t: _buttonPressContext.TimeToTransition/2.0f);
    }

    private void Start()
    {
        Ttp = _buttonState.TTP;
        StartResponse.Invoke();
        OverlayStartScale = Vector3.one * (_buttonState.TTL + _buttonState.PressBufferMax) / _buttonState.TTL;
        OverlayEndscale = Vector3.one * .7f;

    }
    [ContextMenu("SetContextsForListeners")]
    public void SetContextsForListeners()
    {
        var listeners = GetComponents<GameEventArgsListener>().Where(l => l.Event.name.Contains("Context")).ToList();
        listeners.ForEach(l => l.Sender = _buttonPressContext);
    }
    private void Update()
    {
        Frac = _buttonState.CurrentTimeToLive / _buttonState.TTL;
        OverlayTransform.localScale = Vector3.Lerp(OverlayStartScale, OverlayEndscale, t: 1 - Frac);

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

    /// <summary>
    /// </summary>
    /// <param name="args">args[0] is sender</param>
    public void onContextFinished(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;

        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState == _buttonState)
            ContextFinishedResponse.Invoke();
    }

    /// <summary>
    /// </summary>
    /// <param name="args"></param>
    public void onContextTimerEnd(Object[] args)
    {
        var sender = args[0] as ButtonPressContext;
        if (sender == null)
            return;
        var currentState = sender.CurrentState as ButtonPressObject;
        if (currentState != _buttonState)
            return;

        ContextTimerEndResponse.Invoke();

        if (MoveInCamera)
        {
            var x = Random.Range(0f, 1f);
            var y = Random.Range(0f, 1f);
            var z = Random.Range(3f, DistanceFromCamera);
            var newPos = new Vector3(x, y, 3);
            gameObject.MoveInCamera(newPos);
        }
        else
        {
            var canvas = GetComponentInParent<Canvas>();
            var rect = canvas.GetComponent<RectTransform>().rect;
            gameObject.MoveObject(rect.width, rect.height);
        }

        OnButtonGameObjectPositionChange.Raise(ButtonTransform.gameObject);
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
}