using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{   
    // fields
    public Item item_config;
    [SerializeField]
    private Item item_runtime;

    [SerializeField]
    private GameEventArgs ItemPickedUp;

    // properties
    public Item Item
    {
        get { return item_runtime; }
    }

    // Unity methods
    private void Start()
    {
        item_runtime = Instantiate(item_config);
    }

    // methods    
    public void InteractionResponse(Object[] args)
    {
        var item = Instantiate(item_runtime);
        ItemPickedUp.Raise(gameObject, item);        
    }

    public void AddedToInventory(Object[] args)
    {
        if (args[0] != gameObject)
            return;

        GetComponentInChildren<InteractableBehaviour>().InteractableEndInteraction();
        GetComponentInChildren<InteractableBehaviour>().InteractableReleaseInteraction();
        DestroyObject(gameObject);
    }
}
