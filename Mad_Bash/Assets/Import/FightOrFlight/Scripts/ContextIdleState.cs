using UnityEngine;
 
    public class ContextIdleState : IState
    {
        public float CurrentTime { get; set; }

        public void OnEnter(IContext context)
        {
            var buttonPressContext = context as ButtonPressContext;
            
        }

        public void UpdateState(IContext context)
        {
            var buttonPressContext = context as ButtonPressContext;
            CurrentTime -= Time.deltaTime;
            if(CurrentTime <= 0)
                context.ChangeState(buttonPressContext.ButtonPressStates[buttonPressContext.TurnCount]);
        }

        public void OnExit(IContext context)
        {
        }
    }
 