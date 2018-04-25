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
        Current.OnExit(this);
        Current = next;
        CurrentStateName = Current.ToString();
        Current.OnEnter(this);
    }

    public void UpdateContext()
    {
        Current.UpdateState(this);
    }
}

public class GameStartState : IState
{
    public void OnEnter(IContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnExit(IContext context)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GameRunningState());
        if (((GameContext)context).PauseButtonClicked)
            context.ChangeState(new GamePausedState());
    }

    
}

public class GameRunningState : IState
{

    public void OnEnter(IContext context)
    { Debug.Log("enter " + ToString()); }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GamePausedState());
        if (((GameContext)context).PauseButtonClicked)
            context.ChangeState(new GamePausedState());
    }

    public void OnExit(IContext context) { }
}

public class GamePausedState : IState
{
    public void OnEnter(IContext context)
    {
        Debug.Log("enter " + ToString());
    }

    public void UpdateState(IContext context)
    {
        if (Input.GetButtonDown("MenuButton"))
            context.ChangeState(new GameRunningState());
    }

    public void OnExit(IContext context)
    {

    }
}
