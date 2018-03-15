using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour, IInteractable
{   
    // fields
    public Item item_config;
    [SerializeField]
    private Item item_runtime;

    // properties
    public Item Item
    {
        get { return Item; }
    }

    // Unity methods
    private void Start()
    {
        item_runtime = Instantiate(item_config);
    }

    // =========== Interaction System Implementation
    public GameObject Interactor;    

    public void Interact(object token)
    {
        var tokenarray = (object[])token;
        var item = tokenarray[0] as GameObject;
        var player = tokenarray[1] as GameObject;
        player.GetComponent<IContainer>().AddContent(item_runtime);
    }
}
