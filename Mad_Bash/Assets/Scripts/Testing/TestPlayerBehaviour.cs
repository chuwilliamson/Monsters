using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBehaviour : MonoBehaviour, IInteractor
{
    // properties
    [SerializeField]
    private ContainerBehaviour inventory;

    // methods
    public void OpenInventory()
    {
        inventory.Open();
        Debug.Log("opened " + inventory.name);
    }

    // Unity methods
    private void Start()
    {
        inventory = GetComponent<ContainerBehaviour>();        
    }

    private void Update()
    {
        if (Input.GetButtonDown("ViewButton"))
        {
            OpenInventory();
        }

        if (currentInteractable != null)
        {
            if (Input.GetButtonDown("A Button"))
            {
                BeginInteraction();
            }
        }
    }

    public void BeginInteraction()
    {
        GetComponent<MovementBehaviour>().enabled = false;
        currentInteractable.Interact(currentInteractable);
    }

    public void EndInteraction()
    {
        GetComponent<MovementBehaviour>().enabled = true;        
    }

    // =========== Interaction System Implementation
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
}
