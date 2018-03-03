using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContainerBehaviour : MonoBehaviour
{
    public Container container;

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();

        foreach (Object obj in container.contents)
        {
            items.Add(obj as Item);
        }

        return items;
    }

    public void AddItem(Item item)
    {
        container.AddContent(item);
    }

    public void RemoveItem(Item item)
    {
        container.RemoveContent(item);
    }
}
