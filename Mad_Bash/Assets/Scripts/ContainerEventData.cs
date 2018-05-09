using System.Collections.Generic;
using UnityEngine;

public class ContainerEventData : ScriptableObject
{
    private List<Item> _data;

    public List<Item> Data
    {
        get { return _data; }
    }

    public ContainerEventData Init(Container container)
    {
        _data = new List<Item>();
        container.contents.ForEach(o => _data.Add(o as Item));

        return this;
    }
}