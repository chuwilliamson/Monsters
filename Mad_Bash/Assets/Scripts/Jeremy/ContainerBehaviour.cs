using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ContainerBehaviour : MonoBehaviour
{      
    public class ContainerEventData : ScriptableObject
    {       
        private List<Item> _data;

        public List<Item> Data
        {
            get { return _data; }
        }
        
        public void Init(Container container)
        {
            _data = new List<Item>();
            container.contents.ForEach(o => _data.Add(o as Item));
        }
    }

    // fields
    public Container container_config;
    [SerializeField]
    private Container container_runtime;
    [SerializeField]
    private GameEventArgs LootBoxOpened;
    [SerializeField]
    private GameEventArgs LootBoxClosed;

    // properties
    public Container Container
    {
        get { return container_runtime; }
    }

    // methods
    public void Open()
    {
        var data = ScriptableObject.CreateInstance<ContainerEventData>();
        data.Init(container_runtime);        
        LootBoxOpened.Raise(data);
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
}
