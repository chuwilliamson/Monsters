using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Container")]
public class Container : ScriptableObject, IContainer
{       
    public List<Object> contents;
    public int sizeLimit;

    public bool AddContent(Object obj)
    {
        if (contents.Count < sizeLimit)
        {
            contents.Add(obj);
            return true;
        }
        else
        {
            Debug.Log("Container is full");
            return false;
        }
    }

    public bool RemoveContent(Object obj)
    {
        if (contents.Contains(obj))
        {
            contents.Remove(obj);
            return true;
        }
        else
        {
            Debug.Log("Object not in list");
            return false;
        }
    }
}
