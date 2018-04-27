using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonSequenceContext")]
public class ButtonPressContext : ScriptableObject, IContext
{
    private int _turnCount;

    [HideInInspector] public List<ButtonPressObject> ButtonPressStates;

    [Header("Info")] public StringVariable Info;
    public StringVariable Interval; //no more score

    [Tooltip("How many sequences")] public int MaxTurns = 4;

    [Header("Events")] [SerializeField] private GameEventArgs OnContextChanged;
    [SerializeField] private GameEventArgs OnContextFinished;
    [SerializeField] private GameEventArgs OnContextReset;
    [SerializeField] private GameEventArgs OnContextTimerEnd;
    [SerializeField] private GameEventArgs OnContextTimerStart;

    [Header("Scores")] public float PassingScore = 3f;
    public StringVariable ScoreString;

    [Header("States")] public ButtonPressObject State_0;
    public ButtonPressObject State_1;
    public ButtonPressObject State_2;
    public ButtonPressObject State_3;
    private float stateTransitionInterval;


    [Tooltip("Adjust how long before the next state will execute")] public float StateTransitionInterval = 1;
    public StringVariable Timer;
    public StringVariable TimerPressed;

    private float totalScore;
    public IState CurrentState { get; private set; }

    /// <summary>
    ///     use this to set the turncount back to zero and the sequence will restart
    /// </summary>
    public int TurnCount
    {
        get { return _turnCount; }
        set
        {
            _turnCount = value;
            OnContextChanged.Raise(this);
            if (_turnCount == MaxTurns)
                OnContextFinished.Raise(this);
        }
    }

    public float TotalScore
    {
        get { return totalScore; }
        set
        {
            totalScore = value;
            OnContextChanged.Raise(this);
            ScoreString.Value = totalScore.ToString();
        }
    }

    public void ChangeState(IState next)
    {
        CurrentState.OnExit(this);
        CurrentState = next;
        CurrentState.OnEnter(this);
        TurnCount++;
        OnContextChanged.Raise(this);
        stateTransitionInterval = StateTransitionInterval;
        OnContextTimerStart.Raise(this);
    }


    public void ResetContext()
    {
        CurrentState = ButtonPressStates[0];
        CurrentState.OnEnter(this);
        TurnCount = 0;
        TotalScore = 0;
        Interval.Value = StateTransitionInterval.ToString();
        OnContextReset.Raise(this);
    }

    private void OnEnable()
    {
        ButtonPressStates = new List<ButtonPressObject> {State_0, State_1, State_2, State_3};
        ResetContext();
    }

    public void UpdateContext()
    {
        if (TurnCount >= MaxTurns)
        {
            Info.Value = "Finished with score of " + TotalScore;
            return;
        }
        if (stateTransitionInterval <= 0) // this happens only on frames the timer is not counting down.
        {
            CurrentState.UpdateState(this);
        }
        else // this happens only on frames the timer is counting down
        {
            stateTransitionInterval -= Time.deltaTime;
            if (stateTransitionInterval < 0)
            {
                stateTransitionInterval = 0;
                OnContextTimerEnd.Raise(this);
            }
            Info.Value = "Waiting...";
            Interval.Value = stateTransitionInterval.ToString();
        }
    }
}