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

    public void OpenContainer(UnityEngine.Object[] args)
    {
        var sender = args[0] as GameObject;
        var collidedwith = args[1];
        if (collidedwith != gameObject)
            return;

        if (sender != null)
        {
            var containerBehaviour = sender.GetComponent<ContainerBehaviour>();

            if (Input.GetButtonDown("ViewButton"))
            {
                containerBehaviour.Open();
                Debug.Log("opened " + containerBehaviour.name);
            }
        }
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
    }
}
