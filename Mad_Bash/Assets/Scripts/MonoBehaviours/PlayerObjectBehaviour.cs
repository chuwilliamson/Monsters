using UnityEngine;

public class PlayerObjectBehaviour : MonoBehaviour, IInteractor
{
    // fields 
    public CharacterInformation characterInfo_config;

    [SerializeField] [ReadOnly] private CharacterInformation characterInfo_runtime;

    public IInteractable currentInteractable;

    [ReadOnly] public GameObject currentInteractable_GO;

    [SerializeField] private GameEventArgs Interaction_End;

    [SerializeField] private GameEventArgs Interaction_Start;

    // properties
    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }
    }

    // methods
    public void Interaction_Set(IInteractable interactable)
    {
        if (currentInteractable != null)
            return;

        currentInteractable = interactable;
    }

    public void Interaction_Release(IInteractable interactable)
    {
        if (interactable != currentInteractable)
            return;

        currentInteractable_GO = null;
        currentInteractable = null;

        Interaction_End.Raise(this, currentInteractable_GO);
    }

    // Unity methods
    private void Start()
    {
        if (characterInfo_config == null)
            characterInfo_config = Resources.Load("ScriptableObjects/Characters/PlayerConfig") as CharacterInformation;

        characterInfo_runtime = Instantiate(characterInfo_config);
    }

    public void OnInteractionSet(Object[] args)
    {
        var sender = args[0] as GameObject;
        if (sender == null)
            return;

        currentInteractable_GO = args[0] as GameObject;
    }

    public void OnInteractionReleased(Object[] args)
    {
        var sender = args[0] as GameObject;
        if (sender != currentInteractable_GO)
            return;

        currentInteractable_GO = null;
        currentInteractable = null;

        Interaction_End.Raise(this, currentInteractable_GO);
    }

    public void OnSubmitButtonClicked(Object[] args)
    {
        var sender = args[0] as UI_InteractionPromptBehaviour;
        if (sender == null)
            return;

        currentInteractable.Interact(null);
    }
}