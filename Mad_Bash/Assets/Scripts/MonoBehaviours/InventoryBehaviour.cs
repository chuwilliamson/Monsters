using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
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
    public Container inventory_config;
    [SerializeField]
    private Container inventory_runtime;
    [SerializeField]
    private GameEventArgs InventoryOpened;
    [SerializeField]
    private GameEventArgs InventoryClosed;

    // properties
    public Container Container
    {
        get { return inventory_runtime; }
    }

    // methods       
    public void Open()
    {
        var data = ScriptableObject.CreateInstance<ContainerEventData>().Init(inventory_runtime);
        InventoryOpened.Raise(data);
    }

    public void AddItem(Item item)
    {
        inventory_runtime.AddContent(item);
    }

    public void RemoveItem(Item item)
    {
        inventory_runtime.RemoveContent(item);
    }

    // Unity methods
    private void Start()
    {
        inventory_runtime = Instantiate(inventory_config);
    }
}
