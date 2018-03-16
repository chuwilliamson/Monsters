using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour , IContainer
{
    // fields
    public Container container_config;
    [SerializeField]
    private Container container_runtime;

    [SerializeField]
    private GameEventArgs Inventory_Open;
    [SerializeField]
    private GameEventArgs Inventory_Close;

    // properties
    public Container Container
    {
        get { return container_runtime; }
    }    

    // Unity methods
    private void Start()
    {
        container_runtime = Instantiate(container_config);
    }

    private void Update()
    {
        if (Input.GetButtonDown("ViewButton"))
            Open();
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

    [SerializeField]
    private bool opened = false;
    private void Open()
    {
        if (opened)
        {
            //close it
            opened = false;
            Inventory_Close.Raise(gameObject);
        }
        else
        {
            //open it
            opened = true;
            var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(container_runtime);
            Inventory_Open.Raise(gameObject);
        }
    }
}
