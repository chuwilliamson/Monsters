using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Container")]
public class Container : ScriptableObject, IContainer
{
    public List<Object> contents;
    public int sizeLimit;

    public void AddContent(Object obj)
    {
        if (contents.Count < sizeLimit)
        {
            contents.Add(obj);
        }
        else
        {
            throw new System.Exception("Container is full");
        }
    }

    public void RemoveContent(Object obj)
    {
        if (contents.Contains(obj))
        {
            contents.Remove(obj);
        }
        else
        {
            throw new System.Exception("Object not in list");
        }
    }

    public void TransferContent(Object obj, Container container)
    {
        container.AddContent(obj);
        this.RemoveContent(obj);
    }
}
