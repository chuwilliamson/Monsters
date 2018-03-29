using UnityEngine;

public class UI_EventBehaviour : MonoBehaviour, IInteractionSetHandler, IInteractionReleaseHandler, IInteractionBeginHandler,IInteractionEndHandler
{
    // fields
    public GameEventArgs SubmitButtonClicked;    
    [SerializeField]
    public GameObject UI_InteractionPrompt;
    [SerializeField]
    public UnityEngine.UI.Button SubmitButton;

    // Unity methods
    private void OnEnable()
    {
        HidePrompt();   
    }

    private void OnDisable()
    {
        HidePrompt();
    }

    // methods
    private void HidePrompt()
    {
        UI_InteractionPrompt.SetActive(false);
    }

    private void ShowPrompt()
    {
        UI_InteractionPrompt.SetActive(true);
    }

    public void SubmitButtonResponse()
    {
        Debug.Log("SubmitButtonResponse");
        SubmitButtonClicked.Raise(this);
    }

    public void OnInteractionSet(Object[] args)
    {
        Debug.Log("OnInteractionSet");
        ShowPrompt();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(SubmitButton.gameObject);
        SubmitButton.onClick.AddListener(SubmitButtonResponse);
    }
    
    public void OnInteractionRelease(Object[] args)
    {
        Debug.Log("OnInteractionRelease");
        HidePrompt();
        SubmitButton.onClick.RemoveAllListeners();
    }

    public void OnInteractionBegin(Object[] args)
    {
        Debug.Log("OnInteractionBegin");
        HidePrompt();
    }

    public void OnInteractionEnd(Object[] args)
    {
        Debug.Log("OnInteractionEnd");
        ShowPrompt();
    }    
}
