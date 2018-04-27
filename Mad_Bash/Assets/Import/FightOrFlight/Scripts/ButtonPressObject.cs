using UnityEngine;

[CreateAssetMenu(menuName = "ButtonPressObject")]
public class ButtonPressObject : ScriptableObject, IState
{
    public ConditionVariable ButtonCondition;

    [Header("Scoring")] //scoring
    public float ButtonScoreValue = 1;

    [SerializeField] private GameEventArgs _onButtonStateEnter;

    [SerializeField] private GameEventArgs _onButtonStateExit;

    [SerializeField] private GameEventArgs _onButtonStateSuccess;

    [SerializeField] private GameEventArgs _onButtonStateFailure;

    public bool Random;
    public bool Result;

    [Header("TTL")]
    public float TTL;
    public FloatVariable TimeToLive;

    [Header("TTP")]
    public float TTP;
    public FloatVariable TimeToPress;

    public bool ButtonPressed
    {
        get
        {
            Result = TimeToPress.Value > 0 && ButtonCondition.Result;
            
            
            
            
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

    private void SetContextInfo(ButtonPressContext context)
    {
        context.SequenceInfo.TimerStringVariable.Value = TimeToLive.Value.ToString();
        context.SequenceInfo.TimerPressedStringVariable.Value = TimeToPress.Value.ToString();
        context.SequenceInfo.InfoStringVariable.Value = name;
    }
    public void UpdateState(IContext context)
    {
        TimeToLive.Value = (TimeToLive.Value - Time.deltaTime < 0) ? 0 : TimeToLive.Value - Time.deltaTime;
        TimeToPress.Value = (TimeToPress.Value - Time.deltaTime < 0) ? 0 : TimeToPress.Value - Time.deltaTime;

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

            int numstates = ((ButtonPressContext)context).ButtonPressStates.Count;
            int turncount = ((ButtonPressContext)context).TurnCount;
            int nextCount = (turncount + 1) % numstates;
            var stateindex = Random ? UnityEngine.Random.Range(0, numstates) : nextCount;

            context.ChangeState(((ButtonPressContext)context).ButtonPressStates[stateindex]);
        }
    }


}