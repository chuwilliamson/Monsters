using UnityEngine;

[CreateAssetMenu(menuName = "ButtonPressObject")]
public class ButtonPressObject : ScriptableObject, IState
{
    public ConditionVariable ButtonCondition;
    [Header("Info")]
    public int Score;

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
            var result = (TimeToPress.Value > 0 && ButtonCondition.Result);
            if(result) Score = 1;
            return (result || Input.anyKey);
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
        TimeToLive.Value = TTL;
        TimeToPress.Value = TTP;
        Score = 0;
        UpdateInfo(context);
    }

    public void OnExit(IContext context)
    {
        UpdateInfo(context);
        ((ButtonPressContext)context).TotalScore += Score;
    }

    void UpdateInfo(IContext context)
    {
        ((ButtonPressContext)context).Timer.Value = TimeToLive.Value.ToString();
        ((ButtonPressContext)context).TimerPressed.Value = TimeToPress.Value.ToString();
        ((ButtonPressContext)context).Info.Value = name;

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
            var randomstate = Random.Range(0, 3);
            context.ChangeState(((ButtonPressContext)context).ButtonPressStates[randomstate]);
        }
    }
}