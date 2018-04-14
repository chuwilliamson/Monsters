using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "ButtonSequenceContext")]
public class ButtonPressContext : ScriptableObject, IContext
{
    public List<IState> buttons;
    IState currentState;

    public StringVariable Info;
    public StringVariable Timer;
    public StringVariable TimerPressed;
    public StringVariable Interval;

    public ButtonPressObject XState;
    public ButtonPressObject YState;
    public ButtonPressObject AState;
    public ButtonPressObject BState;

    public float passingScore = 3f;
    public bool win = false;
    int turncount = 0;
    public float stateTransitionInterval = 1;

    public float IntervalStart = 1;

    private void OnEnable()
    {
        buttons = new List<IState>() { XState, YState, AState, BState };
        currentState = buttons[0];
        currentState.OnEnter(this);
    }

    public void UpdateContext()
    {
        if (turncount >= 3)
        {
            Debug.Log("Result" + PassOrFail());
            turncount = 0;
            return;
        }

        currentState.UpdateState(this);
    }

    public void ChangeState(IState next)
    {
        if (stateTransitionInterval <= 0)
        {

            PassOrFail();
            currentState.OnExit(this);
            currentState = next;
            next.OnEnter(this);
            turncount++;
            stateTransitionInterval = IntervalStart;
        }
        else
        {
            stateTransitionInterval -= Time.deltaTime;
            if (stateTransitionInterval < 0)
                stateTransitionInterval = 0;
            Interval.Value = stateTransitionInterval.ToString();
        }

    }

    public bool PassOrFail()
    {
        var totalScore = 0;
        foreach (ButtonPressObject b in buttons)
            totalScore += b.Score;
        win = (totalScore >= passingScore);

        return win;
    }

}