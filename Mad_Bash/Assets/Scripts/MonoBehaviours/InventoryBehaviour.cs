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
    private GameEventArgs Inventory_Opened;
    [SerializeField]
    private GameEventArgs Inventory_Closed;
    [SerializeField]
    private GameEventArgs Item_Added;
    [SerializeField]
    private GameEventArgs Item_Removed;

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
    public bool AddContent(Object obj)
    {
        bool result = container_runtime.AddContent((Item)obj);
        return result;
    }

    public bool RemoveContent(Object obj)
    {
        bool result = container_runtime.RemoveContent((Item)obj);
        return result;
    }

    public void OnItemPickUp(params Object[] args)
    {
        var sender = args[0] as GameObject;
        var item = args[1] as Item;
        if (sender == null)
            return;
        
        if (container_runtime.AddContent(item) == true)
        {
            Debug.Log("Added " + item.Name + " to inventory");
            Item_Added.Raise(sender, item);
        }   
    }

    [SerializeField]
    private bool opened = false;
    private void Open()
    {
        if (opened)
        {
            //close it
            opened = false;
            Inventory_Closed.Raise(gameObject);
        }
        else
        {
            //open it
            opened = true;
            var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(container_runtime);
            Inventory_Opened.Raise(data);
        }
    }
}
