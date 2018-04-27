using UnityEngine;

[CreateAssetMenu(menuName = "ButtonPressObject")]
public class ButtonPressObject : ScriptableObject, IState
{
    public ConditionVariable ButtonCondition;

    [Header("Scoring")] //scoring
    public float ButtonScoreValue = 1;

    [SerializeField] private GameEventArgs OnButtonStateEnter;

    [SerializeField] private GameEventArgs OnButtonStateExit;

    public bool RANDOM;
    public bool result;
    public FloatVariable TimeToLive;
    public FloatVariable TimeToPress;

    [Header("TTL")] public float TTL;

    [Header("TTP")] public float TTP;

    public bool ButtonPressed
    {
        get
        {
            result = TimeToPress.Value > 0 && ButtonCondition.Result;
            if (result) ButtonScoreValue = 1;
            return result || Input.anyKey;
        }
    }

    public bool ButtonFinished
    {
        get
        {
            //if user pressed button within threshold
            return TimeToLive.Value <= 0;
        }
    }

    public void OnEnter(IContext context)
    {
        OnButtonStateEnter.Raise(this);
        TimeToLive.Value = TTL;
        TimeToPress.Value = TTP;
        ButtonScoreValue = 0;
        UpdateInfo(context);
    }


    public void OnExit(IContext context)
    {
        UpdateInfo(context);

        ((ButtonPressContext) context).TotalScore += ButtonScoreValue;
        OnButtonStateExit.Raise(this);
    }

    public void UpdateState(IContext context)
    {
        TimeToLive.Value -= Time.deltaTime;
        TimeToPress.Value -= Time.deltaTime;
        if (TimeToPress.Value < 0) TimeToPress.Value = 0f;
        if (TimeToLive.Value < 0) TimeToLive.Value = 0f;
        UpdateInfo(context);
        if (ButtonPressed || ButtonFinished)
        {
            var stateindex = RANDOM ? Random.Range(0, 4) : ((ButtonPressContext) context).TurnCount;
            context.ChangeState(((ButtonPressContext) context).ButtonPressStates[stateindex]);
        }
    }

    private void UpdateInfo(IContext context)
    {
        ((ButtonPressContext) context).Timer.Value = TimeToLive.Value.ToString();
        ((ButtonPressContext) context).TimerPressed.Value = TimeToPress.Value.ToString();
        ((ButtonPressContext) context).Info.Value = name;
    }
}