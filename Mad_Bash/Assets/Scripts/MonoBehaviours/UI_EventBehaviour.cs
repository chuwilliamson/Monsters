using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EventBehaviour : MonoBehaviour
{
    // fields
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject UI_InteractionPrompt;
    [SerializeField]
    private GameObject UI_InteractionMenu;

    // Unity methods
    private void Start()
    {   
        UI_InteractionPrompt.SetActive(false);
        UI_InteractionMenu.SetActive(false);
    }

    // methods
    public void OnInteractionStart(params Object[] args)
    {
        UI_InteractionPrompt.SetActive(false);
        UI_InteractionMenu.SetActive(true);
    }

    public void OnInteractionEnd(params Object[] args)
    {
        UI_InteractionPrompt.SetActive(true);
        UI_InteractionMenu.SetActive(false);
    }

    public void OnInteractorSet(params Object[] args)
    {
        UI_InteractionPrompt.SetActive(true);
    }

    public void OnInteractorRelease(params Object[] args)
    {
        UI_InteractionPrompt.SetActive(false);
        UI_InteractionMenu.SetActive(false);
    }
}
