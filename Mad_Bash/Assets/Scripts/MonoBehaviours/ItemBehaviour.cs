using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{   
    // fields
    public Item item_config;
    [SerializeField]
    private Item item_runtime;
     
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

 
    [SerializeField]
    private GameEventArgs ItemPickedUp;
    
    public void InteractionResponse(params Object[] args)
    {        
        ItemPickedUp.Raise(item_runtime);
        gameObject.SetActive(false);
    }
}
