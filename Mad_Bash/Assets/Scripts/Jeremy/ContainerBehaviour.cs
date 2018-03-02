using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ContainerBehaviour : MonoBehaviour
{
    public Container contents;

    public void AddItem(Item item)
    {
        contents.AddContent(item);
    }

    public void RemoveItem(Item item)
    {
        contents.RemoveContent(item);
    }

    public void TransferItem(Item item, Container destination)
    {
        destination.AddContent(item);
        contents.RemoveContent(item);
    }
}
