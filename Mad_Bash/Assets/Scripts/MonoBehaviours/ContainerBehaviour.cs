using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour, IInteractable, IContainer
{      
   
    // fields
    public Container container_config;
    [SerializeField]
    private Container container_runtime;
    [SerializeField]
    private GameEventArgs ContainerOpened;
    [SerializeField]
    private GameEventArgs ContainerClosed;

    // properties
    public Container Container
    {
        get { return container_runtime; }
    }
    public GameEventArgs InteractionBegin;
    public GameEventArgs InteractionEnded;

    // methods
    public void Open()
    {        
        
    }

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

    // =========== Interaction System Implementation
    public GameObject Interactor;
    [SerializeField]
    private GameEventArgs Interaction_Set;
    [SerializeField]
    private GameEventArgs Interaction_Release;
    bool opened = false;

    public void SetInteraction(params Object[] args)
    {
        Debug.Log("Interaction Set");
        Interactor = (GameObject)args[1];
        Interactor.GetComponent<IInteractor>().Interaction_Set(this);
        Interaction_Set.Raise(gameObject, Interactor);

    }


    public void Interact(object token)
    {
        
        if (opened)
        {
            //close it
            opened = false;
            InteractionEnded.Raise(gameObject);
            
        }
        else
        {
            //open it
            opened = true;
            var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(container_runtime);
            InteractionBegin.Raise(gameObject);            
        }
    }


    public void EndInteraction(params Object[] args)
    {
        Debug.Log("Interaction End");
        if (args[0] == gameObject && Interactor != null)
        {
            Interactor.GetComponent<IInteractor>().Interaction_Release();
            Interaction_Release.Raise(gameObject, Interactor);
            Interactor = null;
        }
    }


}
