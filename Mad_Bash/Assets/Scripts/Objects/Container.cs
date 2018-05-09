using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Container")]
public class Container : ScriptableObject, IContainer
{
    public List<Object> contents;
    public int SizeLimit = 25;
    private void OnEnable()
    {
        contents = new List<Object>();
    }
    public bool AddContent(Object obj)
    {
        if (obj == null)
            return false;
        
        if (contents.Count < SizeLimit)
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
        if (contents == null)
            return false;
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