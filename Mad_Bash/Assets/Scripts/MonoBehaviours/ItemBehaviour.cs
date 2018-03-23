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
        get { return item_runtime; }
    }

    // Unity methods
    private void Start()
    {
        item_runtime = Instantiate(item_config);
    }

    // =========== Interaction System Implementation
    public GameObject Interactor;
    [SerializeField]
    private GameEventArgs Interactor_Set;
    [SerializeField]
    private GameEventArgs Interactor_Release;
    [SerializeField]
    private GameEventArgs Interaction_Start;    
    [SerializeField]
    private GameEventArgs Item_PickUp;
   
    public void Interact(object token)
    {
        Interaction_Start.Raise(this);
    }

    public void SetInteractor(params Object[] args)
    {        
        Interactor = (GameObject)args[1];
        Interactor.GetComponent<IInteractor>().Interaction_Set(this);
        Interactor_Set.Raise(gameObject, Interactor);
    }

    public void ReleaseInteractor(params Object[] args)
    {   
        if (args[0] == gameObject && Interactor != null)
        {
            Interactor.GetComponent<IInteractor>().Interaction_Release();
            Interactor_Release.Raise(gameObject, Interactor);
            Interactor = null;
        }
    }

    public void OnItemPickup(params Object[] args)
    {
        Destroy(gameObject);
    }
}
