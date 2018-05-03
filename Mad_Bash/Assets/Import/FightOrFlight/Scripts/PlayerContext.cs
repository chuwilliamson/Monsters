using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerContext : IContext
{    
    public PlayerContext(IState initialState)
    {
        CurrentState = initialState;
        CurrentState.OnEnter(this);
    }
    
    //we store references here to handle the disabling of monobehaviours specific to 
    //the states. EX: Interacting state will disable the playercontroller

    public PlayerObjectBehaviour PlayerObjectBehaviour { get; set; }
    public PlayerController PlayerController { get; set; }
    public IState CurrentState { get; private set; }

    public void UpdateContext()
    {
        CurrentState.UpdateState(this);
    }

    public void ResetContext()
    {
        CurrentState = new PlayerIdleState();
        CurrentState.OnEnter(this);
    }
    

    public void ChangeState(IState next)
    {
        CurrentState.OnExit(this);
        CurrentState = next;
        CurrentState.OnEnter(this);
    }
}