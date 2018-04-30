using UnityEngine;

public interface IInteractionSetHandler
{
    void OnInteractionSet(Object[] args);
}

public interface IInteractionReleaseHandler
{
    void OnInteractionRelease(Object[] args);
}

public interface IInteractionBeginHandler
{
    void OnInteractionBegin(Object[] args);  
}

public interface IInteractionEndHandler
{
    void OnInteractionEnd(Object[] args);
}

public interface IPhysicsTriggerEnterHandler
{
    void OnPhysicsTriggerEnter(Object[] args);
}

public interface IPhysicsTriggerExitHandler
{
    void OnPhysicsTriggerExit(Object[] args);
}

[RequireComponent(typeof(PhysicsTriggerListener))]
public class InteractableBehaviour : MonoBehaviour, IInteractable, IPhysicsTriggerEnterHandler, IPhysicsTriggerExitHandler
{
    public IInteractor interactor;
    public GameObject interactorGameObject;
    public GameEventArgsResponse Response;
    public GameEventArgs InteractionSet;
    public GameEventArgs InteractionBegin;
    public GameEventArgs InteractionEnd;
    public GameEventArgs InteractionReleased;

    public void Interact(object token)
    {
        InteractableBeginInteraction(token as GameObject);          
    }

    public void InteractableBeginInteraction(Object token)
    {
        InteractionBegin.Raise(gameObject);
        Response.Invoke(new Object[] { gameObject, interactorGameObject, token });
    }

    public void InteractableEndInteraction()
    {
        InteractionEnd.Raise(gameObject, interactorGameObject);
    }

    public void InteractableReleaseInteraction()
    {
        InteractionReleased.Raise(gameObject, interactorGameObject);
    }

    public void OnPhysicsTriggerEnter(Object[] args)
    {
        var sender = args[0] as GameObject;
        var actor = args[1] as GameObject;
        if (sender == null)
            return;

        interactorGameObject = actor;
        interactor = interactorGameObject.GetComponent<IInteractor>();
        interactor.Interaction_Set(this);
        InteractionSet.Raise(gameObject, actor);
    }
    
    public void OnPhysicsTriggerExit(Object[] args)
    {
        var sender = args[0] as GameObject;
        var actor = args[1] as GameObject;
        if (sender == null)
            return;
        
        interactor.Interaction_Release(this);
        interactorGameObject = null;
        interactor = null;
        InteractionReleased.Raise(gameObject, actor);
    }
}
