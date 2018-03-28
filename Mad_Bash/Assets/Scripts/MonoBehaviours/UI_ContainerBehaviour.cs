using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ContainerBehaviour : UI_EventBehaviour
{
    [SerializeField]
    private List<Item> containerContents = new List<Item>();

    public void OnContainerOpen(params Object[] args)
    {
        containerContents = new List<Item>();
        string contentsText = "";

        var data = args[0] as ContainerEventData;
        foreach (Item i in data.Data)
        {
            containerContents.Add(i);
        }

        foreach (Item i in containerContents)
        {
             contentsText += i.Name + "\n";
        }


    }
}
