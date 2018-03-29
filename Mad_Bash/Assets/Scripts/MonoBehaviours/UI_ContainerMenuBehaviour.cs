using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ContainerMenuBehaviour : MonoBehaviour
{
    // fields
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject ContainerMenu;
    [SerializeField]
    private List<Item> containerContents = new List<Item>();

    // Unity methods

    private void OnEnable()
    {   
        ContainerMenu.SetActive(false);
    }

    private void OnDisable()
    {
        ContainerMenu.SetActive(false);
    }

    // methods
    public void OnContainerOpen(Object[] args)
    {
        string contentsText = "";

        var data = args[1] as ContainerEventData;
        foreach (Item i in data.Data)
        {
            containerContents.Add(i);
        }

        foreach (Item i in containerContents)
        {
            contentsText += i.Name + "\n";
        }

        ContainerMenu.GetComponentInChildren<Text>().text = contentsText;

        ContainerMenu.SetActive(true);
    }
    
    public void CloseContainerMenu()
    {
        ContainerMenu.GetComponentInChildren<Text>().text = "";
        containerContents = new List<Item>();
        ContainerMenu.SetActive(false);
    }
}
