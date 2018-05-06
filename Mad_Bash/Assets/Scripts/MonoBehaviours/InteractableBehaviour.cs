using UnityEngine;

[RequireComponent(typeof(PhysicsTriggerListener))]
[DisallowMultipleComponent]
public class InteractableBehaviour : MonoBehaviour, IInteractable, IPhysicsTriggerEnterHandler,
    IPhysicsTriggerExitHandler
{
    public GameEventArgs EventInteraction_Begin;
    public GameEventArgs EventInteraction_End;
    public GameEventArgs EventInteraction_Released;
    public GameEventArgs EventInteraction_Set;
    public IInteractor Interactor;
    public GameObject InteractorGameObject;
    public GameEventArgsResponse BeginResponse;

    public void Interact(object token)
    {
        InteractionBegin(token as GameObject);
    }
    #region callbacks
    public void OnPhysicsTriggerEnter(Object[] args)
    {
        var sender = args[0] as GameObject;
        var actor = args[1] as GameObject;
        if (sender == null)
            return;
        InteractionSet(actor);
    }

    public void OnPhysicsTriggerExit(Object[] args)
    {
        var sender = args[0] as GameObject;
        var actor = args[1] as GameObject;
        if (sender == null||actor==null)
            return;
        InteractionRelease();
    }
    #endregion

    public void InteractionSet(Object actor)
    {
        InteractorGameObject = actor as GameObject;
        Interactor = (InteractorGameObject != null) ? InteractorGameObject.GetComponent<IInteractor>() : null;
        Interactor.SetInteraction(this);

        EventInteraction_Set.Raise(gameObject, actor);
    }

    public void InteractionBegin(Object token)
    {
        EventInteraction_Begin.Raise(gameObject);
        BeginResponse.Invoke(new[] {gameObject, InteractorGameObject, token});
    }

    public void InteractionEnd(Object actor)
    {
        EventInteraction_End.Raise(gameObject, InteractorGameObject);
     
    } 
    
    public void InteractionRelease()
    {
        if(Interactor != null)
        Interactor.ReleaseInteraction(this);
        InteractorGameObject = null;
        Interactor = null;
        EventInteraction_Released.Raise(gameObject, InteractorGameObject);
    }
}