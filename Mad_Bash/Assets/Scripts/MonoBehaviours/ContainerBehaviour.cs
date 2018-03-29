using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour, IContainer
{  
    // fields
    public Container container_config;
    [SerializeField]
    private Container container_runtime;

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
}
