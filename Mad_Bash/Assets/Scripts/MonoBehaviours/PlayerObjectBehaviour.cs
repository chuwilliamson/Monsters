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
            if (interacting)
            {
                if (Input.GetButtonDown("B Button"))
                {
                    Interaction_End.Raise(this, currentInteractable_GO);
                }
            }
            else
            {
                if (Input.GetButtonDown("A Button"))
                {   
                    Interaction_Start.Raise(this, currentInteractable_GO);
                }
            }
        }
    }

    // methods
    public void OnInteractionStart()
    {
        if (currentInteractable == null)
            return;

        Debug.Log("Interaction start");
        interacting = true;
        currentInteractable.Interact(this);
    }

    public void OnInteractionEnd()
    {
        Debug.Log("Interaction end");
        interacting = false;
    }

    public void OnInteractorSet(params Object[] args)
    {
        if ((GameObject)args[1] != gameObject)
            return;
        currentInteractable_GO = args[0] as GameObject;
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

        if (interacting)
            Interaction_End.Raise(this, currentInteractable_GO);
    }
}
