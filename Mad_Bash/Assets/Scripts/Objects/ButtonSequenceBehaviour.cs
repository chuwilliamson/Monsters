using UnityEngine;


/// <summary>
/// MonoBehaviour for executing the Button Sequence for Fight or Flight
/// </summary>
public class ButtonSequenceBehaviour : MonoBehaviour
{
    public ButtonPressContext context;
    public GameObject sphere;
    private void OnEnable()
    {
        context.TurnCount = 0;
    }
 
    private void Update()
    {
        if (context == null)
            return;

        context.UpdateContext();
    }
}