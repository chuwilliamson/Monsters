using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectBehaviour : MonoBehaviour, IInteractor
{
    // fields 
    public CharacterInformation characterInfo_config;
    [SerializeField]
    private CharacterInformation characterInfo_runtime;
    [SerializeField]
    private GameEventArgs Interaction_Start;
    [SerializeField]
    private GameEventArgs Interaction_End;
    [SerializeField]
    public IInteractable currentInteractable;
    public GameObject currentInteractable_GO;
    // properties
    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }
    }

    [SerializeField]
    private bool interacting = false;

    public void OnSubmitButtonClicked(Object[] args)
    {
        var sender = args[0] as UI_EventBehaviour;
        if (sender == null)
            return;
        currentInteractable.Interact(null);
    }



    // Unity methods
    private void Start()
    {
        if (characterInfo_config == null)
        {
            characterInfo_config = Resources.Load("ScriptableObjects/Characters/PlayerConfig") as CharacterInformation;
        }

        characterInfo_runtime = Instantiate(characterInfo_config);
    }


    public void Interaction_Set(IInteractable interactable)
    {
        if (currentInteractable != null)
            return;

        currentInteractable = interactable;
    }

    public void Interaction_Release()
    {
        currentInteractable_GO = null;
        currentInteractable = null;

        Interaction_End.Raise(this, currentInteractable_GO);
    }

    public void Interaction_Release(IInteractable interactable)
    {
        throw new System.NotImplementedException();
    }
}
