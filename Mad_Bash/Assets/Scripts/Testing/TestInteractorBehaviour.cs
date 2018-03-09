using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractorBehaviour : MonoBehaviour, IInteractor
{
    public IInteractable currentInteractable;

    public void Interaction_Set(IInteractable interactable)
    {
        if (currentInteractable != null)
            return;

        currentInteractable = interactable;
    }

    public void Interaction_Release()
    {
        currentInteractable = null;
    }

    private void Update()
    {
        if (currentInteractable != null)
        {
            if (Input.GetButtonDown("A Button"))
            {
                currentInteractable.Interact(currentInteractable);
            }
        }
    }
}
