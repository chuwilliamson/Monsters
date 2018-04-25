using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ButtonSequenceContext")]
public class ButtonPressContext : ScriptableObject, IContext
{
    public delegate void OnContextChange();

    public OnContextChange onContextChange;
    [HideInInspector]
    public List<ButtonPressObject> ButtonPressStates;
    private IState currentState;

    [Header("Info")]
    public StringVariable Info;
    public StringVariable Timer;
    public StringVariable TimerPressed;
    public StringVariable Interval;
    public FloatVariable Score;
    public StringVariable ScoreString;

    [Header("States")]
    public ButtonPressObject State_0;
    public ButtonPressObject State_1;
    public ButtonPressObject State_2;
    public ButtonPressObject State_3; 

    [Header("Scores")]
    public float passingScore = 3f;
    
    /// <summary>
    /// use this to set the turncount back to zero and the sequence will restart
    /// </summary>
    public int TurnCount
    { get; set; }
    
    [Tooltip("How many sequences")]
    public int MaxTurns = 4;
    

    [Tooltip("Adjust how long before the next state will execute")] 
    public float StateTransitionInterval = 1;
    private float stateTransitionInterval;
    

    private void OnEnable()
    {
        ButtonPressStates = new List<ButtonPressObject> { State_0, State_1, State_2, State_3 };
        currentState = ButtonPressStates[0];
        stateTransitionInterval = StateTransitionInterval;
        TurnCount = 0;
        Info.Value = "Starting";
        Interval.Value = StateTransitionInterval.ToString();
 
    }

    public void UpdateContext()
    {
        if (TurnCount >= MaxTurns)
        {
            Info.Value = "Finished with score of " + TotalScore;
            return;
        }
        if (stateTransitionInterval <= 0)
        {
            currentState.UpdateState(this);
        }
        else
        {
            stateTransitionInterval -= Time.deltaTime;
            if (stateTransitionInterval < 0) stateTransitionInterval = 0;
            Info.Value = "Waiting...";
            Interval.Value = stateTransitionInterval.ToString();
        }
    }

    public void ChangeState(IState next)
    {
        currentState.OnExit(this);
        currentState = next;
        next.OnEnter(this);
        TurnCount++;
        stateTransitionInterval = StateTransitionInterval;

    }

    public float TotalScore
    {
        get { return Score.Value; }
        set
        {
            if(onContextChange != null)
                onContextChange.Invoke();
            Score.Value = value;
            ScoreString.Value = Score.Value.ToString();
        }
    }
}