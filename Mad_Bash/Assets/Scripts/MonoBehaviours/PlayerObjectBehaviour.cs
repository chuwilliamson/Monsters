using UnityEngine;

[DisallowMultipleComponent]
public class PlayerObjectBehaviour : MonoBehaviour, IInteractor
{
    public GameObject VCAM_FREELOOK;
    // fields 
    public CharacterInformation characterInfo_config;

    [SerializeField] [ReadOnly] private CharacterInformation characterInfo_runtime;

    private IContext Context;

    public IInteractable CurrentInteractable;

    [ReadOnly] public GameObject CurrentInteractable_GO;

    // properties
    public CharacterInformation CharacterInfo
    {
        get { return characterInfo_runtime; }
    }

    // Unity methods
    private void Start()
    {
        characterInfo_config = characterInfo_config == null
            ? Resources.Load<CharacterInformation>("ScriptableObjects/Characters/PlayerConfig")
            : characterInfo_config;
        characterInfo_runtime = Instantiate(characterInfo_config);

        Context = new PlayerContext(new PlayerIdleState())
        {
            CharacterMovement = GetComponent<ICharacterMovement>(),
            PlayerObjectBehaviour = this
        };
    }

    private void Update()
    {
        Context.UpdateContext();
    }

    #region INTERACTION

    // methods
    public void SetInteraction(IInteractable interactable)
    {
        if (CurrentInteractable != null)
            return;
        CurrentInteractable = interactable;
    }
    
    public void ReleaseInteraction(IInteractable interactable)
    {
        if (interactable == null || interactable != CurrentInteractable)
            return;

        CurrentInteractable_GO = null;
        CurrentInteractable = null;
    }

    public void ChangeToInteractState(Object[] args)
    {
        //THIS IS SO BAD... we have to do this because
        //the interaction system needs to fire when we enter the gremlin trigger
        Context.ChangeState(new PlayerInteractState());
    }

    #endregion
}