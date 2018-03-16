using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectBehaviour : MonoBehaviour, IInteractor
{
    public CharacterInformation characterInfo_config;
    [SerializeField]
    private CharacterInformation characterInfo_runtime;

    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }        
    }

    public IInteractable currentInteractable;

    public void Interaction_Set(IInteractable interactable)
    {
        if (currentInteractable != null)
            return;

        currentInteractable = interactable;
    }

    public void Interaction_Release()
    {
        currentInteractable = null;
    }

    public void Update()
    {
        if (currentInteractable != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
                currentInteractable.Interact(currentInteractable);
            }
        }
    }

    private void Start()
    {
        if (characterInfo_config == null)
        {
            characterInfo_config = Resources.Load("ScriptableObjects/Characters/PlayerConfig") as CharacterInformation;
        }

        characterInfo_runtime = Instantiate(characterInfo_config);
    }
}
