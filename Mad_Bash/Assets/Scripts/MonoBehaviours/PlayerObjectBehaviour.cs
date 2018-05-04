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
        Cursor.visible = !Cursor.visible;
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

    public void OnGremlinInteractionSet(Object[] args)
    {
        //THIS IS SO BAD... we have to do this because
        //the interaction system needs to fire when we enter the gremlin trigger
        Context.ChangeState(new PlayerInteractState());
    }
 
    #endregion
}