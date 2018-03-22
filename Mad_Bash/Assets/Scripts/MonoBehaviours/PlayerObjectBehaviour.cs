using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectBehaviour : MonoBehaviour, IInteractor
{
    // fields 
    public IInteractable currentInteractable;

    public CharacterInformation characterInfo_config;
    [SerializeField]
    private CharacterInformation characterInfo_runtime;

    // properties
    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }
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

    public void Update()
    {
        if (currentInteractable != null)
        {
            if (Input.GetButtonDown("A Button"))
            {
                currentInteractable.Interact(this);
            }
        }
    }

    // methods
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
}
