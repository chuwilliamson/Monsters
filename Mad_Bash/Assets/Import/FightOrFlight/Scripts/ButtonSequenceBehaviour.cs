using UnityEngine;

/// <summary>
///     MonoBehaviour for executing the Button Sequence for Fight or Flight
/// </summary>
public class ButtonSequenceBehaviour : MonoBehaviour
{
    public ButtonPressContext Context; //context

    private void OnEnable()
    {
        Context.ResetContext();
    }

    private void Update()
    {
        if (Context == null)
            return;

        Context.UpdateContext();
    }
}