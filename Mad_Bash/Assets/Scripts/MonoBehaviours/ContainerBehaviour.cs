using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour, IInteractable, IContainer
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
    public void AddContent(Object obj)
    {
        container_runtime.AddContent((Item)obj);
    }

    public void RemoveContent(Object obj)
    {
        container_runtime.RemoveContent((Item)obj);
    }
    
    // =========== Interaction System Implementation
    public GameObject Interactor;
    [SerializeField]
    private GameEventArgs Interactor_Set;
    [SerializeField]
    private GameEventArgs Interactor_Release;
    [SerializeField]
    private GameEventArgs containerOpen;

    public void Interact(object token)
    {
        Debug.Log("Interact called");
        var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(container_runtime);
        containerOpen.Raise(data);
    }

    public void SetInteractor(params Object[] args)
    {
        if ((GameObject)args[0] != gameObject)
            return;
        Debug.Log("Interactor Set");
        Interactor = (GameObject)args[1];
        Interactor.GetComponent<IInteractor>().Interaction_Set(this);
        Interactor_Set.Raise(gameObject, Interactor);
    }

    public void ReleaseInteractor(params Object[] args)
    {
        if (args[0] == gameObject && Interactor != null)
        {
            Debug.Log("Interactor Release");
            Interactor.GetComponent<IInteractor>().Interaction_Release();
            Interactor_Release.Raise(gameObject, Interactor);
            Interactor = null;
        }
    }

    public void OnContainerOpen()
    { 
        
    }
}
