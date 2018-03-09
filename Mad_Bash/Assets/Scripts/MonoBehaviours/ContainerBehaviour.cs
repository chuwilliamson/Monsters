using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour, IInteractable
{      
    public class ContainerEventData : ScriptableObject
    {       
        private List<Item> _data;

        public List<Item> Data
        {
            get { return _data; }
        }
        
        public ContainerEventData Init(Container container)
        {
            _data = new List<Item>();
            container.contents.ForEach(o => _data.Add(o as Item));

            return this;
        }
    }

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

    // methods       
    public void Open()
    {
        Debug.Log("Container Opened");
        var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(container_runtime);
        ContainerOpened.Raise(data);
    }

    public void AddItem(Item item)
    {
        container_runtime.AddContent(item);
    }

    public void RemoveItem(Item item)
    {
        container_runtime.RemoveContent(item);
    }

    // Unity methods
    private void Start()
    {
        container_runtime = Instantiate(container_config);
    }

    // Interaction System Implementation
    public GameObject Interactor;
    [SerializeField]
    private GameEventArgs Interaction_Set;
    [SerializeField]
    private GameEventArgs Interaction_Release;

    public void Interact(object token)
    {
        Debug.Log("Interact has been called with token of " + token.ToString());
        Open();
    }

    public void SetInteraction(params Object[] args)
    {
        Debug.Log("Interaction Set");
        Interactor = (GameObject)args[1];
        Interactor.GetComponent<IInteractor>().Interaction_Set(this);
        Interaction_Set.Raise(gameObject, Interactor);
    }

    public void EndInteraction(params Object[] args)
    {
        Debug.Log("Interaction End");
        if (args[0] == gameObject && Interactor != null)
        {
            Interaction_Release.Raise(gameObject, Interactor);
            Interactor.GetComponent<IInteractor>().Interaction_Release();
            Interactor = null;
        }
    }
}
