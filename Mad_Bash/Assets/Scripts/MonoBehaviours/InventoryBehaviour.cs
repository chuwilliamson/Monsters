using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour, IContainer
{
    // fields
    public Container container_config;
    [SerializeField]
    private Container container_runtime;
    [SerializeField]
    private GameEventArgs InventoryOpen;
    [SerializeField]
    private GameEventArgs InventoryClose;

    // properties
    public Container Container
    {
        get { return container_runtime; }
    }

    // methods
    public void AddContent(Object obj)
    {
        container_runtime.AddContent((Item)obj);
    }

    public void RemoveContent(Object obj)
    {
        container_runtime.RemoveContent((Item)obj);
    }

    // Unity methods
    private void Start()
    {
        container_runtime = Instantiate(container_config);
    }

    [SerializeField]
    private bool opened = false;
    private void Update()
    {
        if (Input.GetButtonDown("ViewButton"))
        {
            if (opened)
            {
                //close it
                opened = false;
                InventoryClose.Raise(gameObject);
            }
            else
            {
                //open it
                opened = true;
                var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(container_runtime);
                InventoryOpen.Raise(gameObject);
            }
        }
    }
}
