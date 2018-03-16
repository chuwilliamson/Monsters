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
    [SerializeField]
    private GameEventArgs Interactor_Set;
    [SerializeField]
    private GameEventArgs Interactor_Release;
    [SerializeField]
    private GameEventArgs Interaction_Start;
    [SerializeField]
    private GameEventArgs Interaction_End;

    [SerializeField]
    private bool opened = false;
    public void Interact(object token)
    {
        if (opened)
        {
            //close it
            opened = false;
            Interaction_End.Raise(gameObject);
        }
        else
        {
            //open it
            opened = true;            
            Interaction_Start.Raise(gameObject);

            var tokenarray = (object[])token;
            var item = tokenarray[0] as GameObject;
            var player = tokenarray[1] as GameObject;
            player.GetComponent<IContainer>().AddContent(item_runtime);
        }
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
}
