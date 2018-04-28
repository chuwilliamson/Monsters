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
 
    public float CurrentTimeToLive { get; set; }

    public float CurrentTimeToPress { get; set; }

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
            var maxcheck = CurrentTimeToLive < TTL - PressBufferMax;
            var mincheck = CurrentTimeToPress >0;
            Result = mincheck && maxcheck && ButtonCondition.Result;
            return Result || Input.anyKeyDown;
        }
    }

    public bool ButtonFinished
    {
        get { return CurrentTimeToLive <= 0; }
    }

    public void OnEnter(IContext context)
    {
        _onButtonStateEnter.Raise(this);
        CurrentTimeToLive = TTL;
        CurrentTimeToPress = TTP;
        ButtonScoreValue = 0; 
    }


    public void OnExit(IContext context)
    {
        ((ButtonPressContext)context).TotalScore += ButtonScoreValue;
 
        _onButtonStateExit.Raise(this);
    }

    public void UpdateState(IContext context)
    {
        CurrentTimeToLive -= Time.deltaTime;

        if(CurrentTimeToLive < TTL - PressBufferMax)
            CurrentTimeToPress -= Time.deltaTime;

        var maxcheck = CurrentTimeToLive < TTL - PressBufferMax;
        var mincheck = CurrentTimeToPress > 0;

        ShouldPress.Value = maxcheck && mincheck ? "yes" : "no"; 

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

//            var numstates = ((ButtonPressContext)context).ButtonPressStates.Count;
//            var turncount = ((ButtonPressContext)context).TurnCount;
//            var nextCount = (turncount + 1) % numstates;
//            var stateindex = Random ? UnityEngine.Random.Range(0, 4) : nextCount;

            context.ChangeState(((ButtonPressContext)context).NextState);
        }
    } 
}