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
    private GameEventArgs Interaction_End;
    public IInteractable currentInteractable;
    [SerializeField]
    private bool interacting = false;

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
            if (interacting != true)
            {
                if (Input.GetButtonDown("A Button"))
                {
                    interacting = true;
                    currentInteractable.Interact(this);                    
                }
            }
            else
            {
                if (Input.GetButtonDown("B Button"))
                {
                    interacting = false;
                    Interaction_End.Raise();
                }
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
