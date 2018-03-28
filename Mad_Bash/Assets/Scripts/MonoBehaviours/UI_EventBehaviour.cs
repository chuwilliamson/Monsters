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
    public GameObject UI_InteractionPrompt;
    [SerializeField]
    public GameObject UI_InteractionMenu;

    // Unity methods
    private void Start()
    {   
        UI_InteractionPrompt.SetActive(false);
        UI_InteractionMenu.SetActive(false);
    }

    private void Update()
    {
        UI_InteractionPrompt.transform.rotation = Camera.main.transform.rotation;
    }

    // methods
    public void OnInteractionStart(params Object[] args)
    {
        if (parent != (GameObject)args[1])
            return;
        UI_InteractionPrompt.SetActive(false);
        UI_InteractionMenu.SetActive(true);
    }

    public void OnInteractionEnd(params Object[] args)
    {
        if (parent != (GameObject)args[1])
            return;
        UI_InteractionPrompt.SetActive(true);
        UI_InteractionMenu.SetActive(false);
    }

    public void OnInteractorSet(params Object[] args)
    {
        if (parent != (GameObject)args[0])
            return;
        UI_InteractionPrompt.SetActive(true);
    }

    public void OnInteractorRelease(params Object[] args)
    {
        if (parent != (GameObject)args[0])
            return;
        UI_InteractionPrompt.SetActive(false);
        UI_InteractionMenu.SetActive(false);
    }    
}
