using UnityEngine;

[CreateAssetMenu(menuName = "ButtonPressObject")]
public class ButtonPressObject : ScriptableObject, IState
{
    [SerializeField]
    private GameEventArgs _onButtonStateEnter;

    [SerializeField]
    private GameEventArgs _onButtonStateExit;

    [SerializeField]
    private GameEventArgs _onButtonStateFailure;

    [SerializeField]
    private GameEventArgs _onButtonStateSuccess;

    public ConditionVariable ButtonCondition;

    [Header("Scoring")] //scoring
    public float ButtonScoreValue = 1;

    public bool Random;
    public bool Result;
    public FloatVariable TimeToLive;
    public FloatVariable TimeToPress;

    [Header("TTL")]
    public float TTL;

    [Header("TTP")]
    public float TTP;

    public float PressBufferMax = 1f;
    public float PressBufferMin = .0f;
    public StringVariable ShouldPress;
    public bool ButtonPressed
    {
        get
        {
            var maxcheck = TimeToLive.Value < TTL - PressBufferMax;
            var mincheck = TimeToPress.Value > 0;
            Result = mincheck && maxcheck && ButtonCondition.Result;
            return Result || Input.anyKey;
        }
    }

    public bool ButtonFinished
    {
        get { return TimeToLive.Value <= 0; }
    }

    public void OnEnter(IContext context)
    {
        _onButtonStateEnter.Raise(this);
        TimeToLive.Value = TTL;
        TimeToPress.Value = TTP;
        ButtonScoreValue = 0;
        SetContextInfo((ButtonPressContext)context);
    }


    public void OnExit(IContext context)
    {
        ((ButtonPressContext)context).TotalScore += ButtonScoreValue;
        SetContextInfo((ButtonPressContext)context);

        _onButtonStateExit.Raise(this);
    }

    public void UpdateState(IContext context)
    {
        TimeToLive.Value -= Time.deltaTime;
        if(TimeToLive.Value < TTL - PressBufferMax)
            TimeToPress.Value -= Time.deltaTime;
        ShouldPress.Value = TimeToLive.Value < TTL - PressBufferMax ? "yes" : "no";

        SetContextInfo((ButtonPressContext)context);

        if (ButtonPressed || ButtonFinished)
        {
            if (Result)
            {
                _onButtonStateSuccess.Raise(this);
                ButtonScoreValue = 1;
            }
            else
            {
                _onButtonStateFailure.Raise(this);
            }

            var numstates = ((ButtonPressContext)context).ButtonPressStates.Count;
            var turncount = ((ButtonPressContext)context).TurnCount;
            var nextCount = (turncount + 1) % numstates;
            var stateindex = Random ? UnityEngine.Random.Range(0, 4) : nextCount;

            context.ChangeState(((ButtonPressContext)context).ButtonPressStates[stateindex]);
        }
    }

    private void SetContextInfo(ButtonPressContext context)
    {
        context.SequenceInfo.TimerStringVariable.Value = TimeToLive.Value.ToString();
        context.SequenceInfo.TimerPressedStringVariable.Value = TimeToPress.Value.ToString();
        context.SequenceInfo.InfoStringVariable.Value = name;
    }
}