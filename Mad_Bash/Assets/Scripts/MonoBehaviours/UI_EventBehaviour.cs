using UnityEngine;


public class UI_EventBehaviour : MonoBehaviour, IInteractionSetHandler, IInteractionReleaseHandler, IInteractionBeginHandler,IInteractionEndHandler
{
    public GameEventArgs SubmitButtonClicked;
    [SerializeField]
    public GameObject UI_InteractionPrompt;
    [SerializeField]
    public UnityEngine.UI.Button SubmitButton;

    private void OnEnable()
    {
        HidePrompt();   
    }

    private void OnDisable()
    {
        HidePrompt();
    }

    public void OnInteractionSet(Object[] args)
    {
        ShowPrompt();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(SubmitButton.gameObject);
        SubmitButton.onClick.AddListener(()=> { SubmitButtonClicked.Raise(this); });


    }
    
    public void OnInteractionRelease(Object[] args)
    {
        HidePrompt();
    }

    public void OnInteractionBegin(Object[] args)
    {
        HidePrompt();
    }

    public void OnInteractionEnd(Object[] args)
    {
        ShowPrompt();
    }


    private void HidePrompt()
    {
        UI_InteractionPrompt.SetActive(false);
    }

    private void ShowPrompt()
    {
        UI_InteractionPrompt.SetActive(true);
    }

}

