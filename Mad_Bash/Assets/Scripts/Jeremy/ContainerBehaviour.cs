using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContainerBehaviour : MonoBehaviour
{      
    public Container container_config;
    [SerializeField]
    private Container container_runtime;

    [SerializeField]
    private GameEventArgs LootBoxOpened;
    [SerializeField]
    private GameEventArgs LootBoxClosed;

    private void Start()
    {
        container_runtime = Instantiate(container_config);
    }

    public void Open()
    {
        LootBoxOpened.Raise(container_runtime);
    }

    public void Close()
    {
        LootBoxClosed.Raise(container_runtime);
    }

    public Container Container
    {
        get { return container_runtime; }
    }

    public void AddItem(Item item)
    {
        container_runtime.AddContent(item);
    }

    public void RemoveItem(Item item)
    {
        container_runtime.RemoveContent(item);
    }
}
