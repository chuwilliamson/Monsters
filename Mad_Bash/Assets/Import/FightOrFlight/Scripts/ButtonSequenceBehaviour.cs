using UnityEngine;

/// <summary>
///     MonoBehaviour for executing the Button Sequence for Fight or Flight
/// </summary>
public class ButtonSequenceBehaviour : MonoBehaviour
{
    public ButtonPressContext context; //context

    private void OnEnable()
    {
        context.ResetContext();
    }

    private void Update()
    {
        if (context == null)
            return;

        context.UpdateContext();
    }
}