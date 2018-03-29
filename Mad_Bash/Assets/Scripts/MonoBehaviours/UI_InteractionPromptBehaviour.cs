using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_InteractionPromptBehaviour : MonoBehaviour, IInteractionSetHandler, IInteractionReleaseHandler, IInteractionBeginHandler,IInteractionEndHandler
{
    // fields    
    [SerializeField]
    private GameObject interactionPromptCanvas;
    [SerializeField]
    private GameObject SubmitButton;
    [SerializeField]
    private GameObject CancelButton;
    [SerializeField]
    private GameEventArgs SubmitButtonClicked;
    [SerializeField]
    private GameEventArgs CancelButtonClicked;

    // Unity methods
    private void OnEnable()
    {
        interactionPromptCanvas.SetActive(false);
        SubmitButton.SetActive(false);
        CancelButton.SetActive(false);
    }

    private void OnDisable()
    {
        HidePrompt();
    }

    // methods
    private void HidePrompt()
    {
        interactionPromptCanvas.SetActive(false);
        SubmitButton.SetActive(false);
        CancelButton.SetActive(true);
    }

    private void ShowPrompt()
    {
        interactionPromptCanvas.SetActive(true);
        SubmitButton.SetActive(true);
        CancelButton.SetActive(false);
    }

    public void SubmitButtonResponse()
    {
        Debug.Log("SubmitButtonResponse");
        SubmitButtonClicked.Raise(this);
        HidePrompt();
    }

    public void CancelButtonResponse()
    {
        Debug.Log("CancelButtonResponse");
        CancelButtonClicked.Raise(this);
        ShowPrompt();
    }

    public void OnInteractionSet(Object[] args)
    {
        Debug.Log("OnInteractionSet");
        ShowPrompt();
    }
    
    public void OnInteractionRelease(Object[] args)
    {
        Debug.Log("OnInteractionRelease");
        interactionPromptCanvas.SetActive(false);
        SubmitButton.SetActive(false);
        CancelButton.SetActive(false);
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
