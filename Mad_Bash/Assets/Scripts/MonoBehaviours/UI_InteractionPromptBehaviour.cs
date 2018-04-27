using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UI_InteractionPromptBehaviour : MonoBehaviour, IInteractionSetHandler, IInteractionReleaseHandler, IInteractionBeginHandler, IInteractionEndHandler, ICancelHandler
{
    // fields    
    [SerializeField]
    private GameObject interactionPromptCanvas;
    [SerializeField]
    private GameObject SubmitButton;

    //private GameObject CancelButton;
    [SerializeField]
    private GameEventArgs SubmitButtonClicked;
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
        interactionPromptCanvas.SetActive(false); 
    }

    private void ShowPrompt()
    {
        interactionPromptCanvas.SetActive(true); 
        EventSystem.current.SetSelectedGameObject(SubmitButton);
    }
 
 

    public void OnInteractionSet(Object[] args)
    {
        Debug.Log("OnInteractionSet");
        ShowPrompt();
        EventSystem.current.SetSelectedGameObject(SubmitButton); 
            
    }

    public void OnInteractionRelease(Object[] args)
    {
        Debug.Log("OnInteractionRelease");
        HidePrompt();
        
 
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

    public void OnCancel(BaseEventData eventData)
    {
        Debug.Log("cancel");

        HidePrompt();

    }

    public void OnButtonClick()
    {
        SubmitButtonClicked.Raise(this);
    }
}
