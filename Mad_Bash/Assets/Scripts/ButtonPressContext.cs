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
    public int turncount;
    public int MaxTurns = 4;
    public float stateTransitionInterval = 1;
    public float IntervalStart = 1;

    private void OnEnable()
    {
        ButtonPressStates = new List<ButtonPressObject> { State_0, State_1, State_2, State_3 };
        currentState = ButtonPressStates[0];
    }

    public void UpdateContext()
    {
        if (turncount >= MaxTurns)
        {
            Info.Value = "Finished with score of " + ScoreString.Value;
            return;
        }
            

        if (stateTransitionInterval <= 0)
        {
            currentState.UpdateState(this);
        }
            
        else
        {
            stateTransitionInterval -= Time.deltaTime;
            if (stateTransitionInterval < 0)
                stateTransitionInterval = 0;
            Info.Value = "Waiting...";
            Interval.Value = stateTransitionInterval.ToString();
        }
    }

    public void ChangeState(IState next)
    {
        Debug.Log("");
        currentState.OnExit(this);
        currentState = next;
        next.OnEnter(this);
        turncount++;
        stateTransitionInterval = IntervalStart;

    }

    public float TotalScore
    {
        get { return Score.Value; }
        set
        {
            onContextChange.Invoke();
            Score.Value = value;
            ScoreString.Value = Score.Value.ToString();
        }
    }
}