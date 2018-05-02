using UnityEngine;

[CreateAssetMenu(menuName = "GameContext")]
public class GameContext : ScriptableObject, IContext
{
    private IState Current;
    public string CurrentStateName;
    public GameObject MainMenu;

    public bool PauseButtonClicked { get; set; }

    public void ResetContext()
    {
        throw new System.NotImplementedException();
    }

    public IState CurrentState { get; private set; }

    /// <summary>
    ///     this should not be called by anyone but the states that funnel through here
    /// </summary>
    /// <param name="next"></param>
    public void ChangeState(IState next)
    {
        Current.OnExit(this);
        Current = next;
        CurrentStateName = Current.ToString();
        Current.OnEnter(this);
    }

    private void OnEnable()
    {
        Current = new GameStartState();
    }

    public void UpdateContext()
    {
        Current.UpdateState(this);
    }
}