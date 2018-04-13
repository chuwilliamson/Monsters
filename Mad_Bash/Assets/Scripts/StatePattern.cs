using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "GameContext")]
public class GameContext : ScriptableObject, IContext
{
    IState Current;
    public string CurrentStateName;
    public GameObject MainMenu;

    public bool PauseButtonClicked { get; set; }
    private void OnEnable()
    {
        Current= new GameStartState();
    }
    /// <summary>
    /// this should not be called by anyone but the states that funnel through here
    /// </summary>
    /// <param name="next"></param>
    public void ChangeState(IState next)
    {
        Current.OnExit();
        Current = next;
        CurrentStateName = Current.ToString();
        Current.OnEnter();
    }

    public void UpdateContext()
    {
        Current.UpdateState(this);
    }
}

public class GameStartState : IState
{
    public void OnEnter()
    {
        Debug.Log("enter " + ToString());
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GameRunningState());
        if (((GameContext)context).PauseButtonClicked)
            context.ChangeState(new GamePausedState());
    }

    public void OnExit() { }
}

public class GameRunningState : IState
{

    public void OnEnter()
    { Debug.Log("enter " + ToString()); }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GamePausedState());
        if (((GameContext)context).PauseButtonClicked)
            context.ChangeState(new GamePausedState());
    }

    public void OnExit() { }
}

public class GamePausedState : IState
{
    public void OnEnter()
    {
        Debug.Log("enter " + ToString());
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GameRunningState());
    }

    public void OnExit()
    {

    }
}
