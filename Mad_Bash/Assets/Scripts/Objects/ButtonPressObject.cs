using UnityEngine;

[CreateAssetMenu(menuName = "ButtonPressObject")]
public class ButtonPressObject : ScriptableObject, IState
{
    public string InputName;
    public float TimeToLive = 1f;
    public float TimeToPress = 0.5f;
    public int Score;
    public bool ButtonPressed;

    public bool RESULT { get; private set; }

    public bool ButtonFinished
    {
        get
        {
            RESULT = TimeToPress > 0 && Input.GetButtonDown(InputName);
            TimeToLive -= Time.deltaTime;
            TimeToPress -= Time.deltaTime;

            if (TimeToPress < 0)
                TimeToPress = 0;
            if (TimeToLive < 0)
                TimeToLive = 0;

            return TimeToLive <= 0;
        }
    }

    public void OnEnter(IContext context)
    {
        ((ButtonPressContext)context).Info.Value = this.ToString();

        TimeToLive = 1f;
        TimeToPress = 0.5f;
        Score = 0;
        ButtonPressed = false;

        Debug.Log("changestate " + this);
    }

    public void OnExit(IContext context)
    {
    }

    public void UpdateState(IContext context)
    {
        ((ButtonPressContext) context).Timer.Value = TimeToLive.ToString();
        ((ButtonPressContext) context).TimerPressed.Value = TimeToPress.ToString();
        if (!ButtonFinished) return;
        Score = RESULT ? 1 : 0;
        var randomstate = Random.Range(0, 3);
        context.ChangeState(((ButtonPressContext) context).ButtonPressStates[randomstate]);
    }
}