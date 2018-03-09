using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractableBehaviour : MonoBehaviour, IInteractable
{
    public GameObject Interactor;
    [SerializeField]
    private GameEventArgs Interaction_Set;
    [SerializeField]
    private GameEventArgs Interaction_Release;

    public void Interact(object token)
    {   
        Debug.Log("Interact has been called with token of " + token.ToString());
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

    // will be implemented by interactable
    public virtual void Interaction(object token) { }
}
