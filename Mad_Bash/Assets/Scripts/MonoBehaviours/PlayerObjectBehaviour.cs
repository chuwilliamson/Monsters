using UnityEngine;

[DisallowMultipleComponent]
public class PlayerObjectBehaviour : MonoBehaviour, IInteractor
{
    // fields 
    public CharacterInformation characterInfo_config;

    [SerializeField]
    [ReadOnly]
    CharacterInformation characterInfo_runtime;

    private IContext Context;

    public IInteractable CurrentInteractable;

    [ReadOnly]
    public GameObject CurrentInteractable_GO;

    // properties
    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }
    }

    // Unity methods
    void Start()
    {
        characterInfo_runtime = characterInfo_config == null
            ? Instantiate(original: characterInfo_config)
            : Resources.Load<CharacterInformation>("ScriptableObjects/Characters/PlayerConfig");

        Context = new PlayerContext(new PlayerIdleState())
        {
            PlayerController = GetComponent<PlayerController>(),
            PlayerObjectBehaviour = this,            
        };
    }

    void Update()
    {
        Context.UpdateContext();
    }

    #region INTERACTION

    // methods
    public void Interaction_Set(IInteractable interactable)
    {
        if (CurrentInteractable != null)
            return;
        CurrentInteractable = interactable;
    }

    public void Interaction_Release(IInteractable interactable)
    {
        if (interactable != CurrentInteractable)
            return;

        CurrentInteractable_GO = null;
        CurrentInteractable = null;
    }
 
    #endregion
}