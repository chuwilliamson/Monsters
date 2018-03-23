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
    private GameEventArgs Item_PickUp;
   
    public void Interact(object token)
    {
        Debug.Log("Interact called");
        var item = Instantiate(item_runtime);        
        Item_PickUp.Raise(gameObject, item);
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

    public void OnItemPickup(params Object[] args)
    {
        if (gameObject != (GameObject)args[0])
            return;

        Debug.Log("OnItemPickup");
        Interactor.GetComponent<IInteractor>().Interaction_Release();
        Interactor_Release.Raise(gameObject, Interactor);
        gameObject.SetActive(false);
    }
}
