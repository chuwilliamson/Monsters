using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBehaviour : MonoBehaviour
{
    // fields
    public int health;

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
        inventory = GetComponentInChildren<ContainerBehaviour>();
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
                currentInteractable.Interact(currentInteractable);
            }
        }
    }

    // Interaction System Implementation
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
