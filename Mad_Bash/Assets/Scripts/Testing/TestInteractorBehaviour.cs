using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestInteractorBehaviour : MonoBehaviour, IInteractor
{
    public IInteractable currentInteractable;

    public virtual void Interaction_Set(IInteractable interactable)
    {
        if (currentInteractable != null)
            return;

        currentInteractable = interactable;
    }

    public virtual void Interaction_Release()
    {
        currentInteractable = null;
    }

    public virtual void Update()
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
