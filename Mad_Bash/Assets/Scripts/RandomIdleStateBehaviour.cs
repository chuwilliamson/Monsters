using UnityEngine;

public class RandomIdleStateBehaviour : StateMachineBehaviour
{
    public static readonly int IDLEINDEX = Animator.StringToHash("IdleIndex");
    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger(IDLEINDEX, Random.Range(0, 3));
    }

}