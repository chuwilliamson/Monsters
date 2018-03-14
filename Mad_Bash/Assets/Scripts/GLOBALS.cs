﻿using System.Collections.Generic;
using UnityEngine;

public interface IContainer
{
    void AddContent(Object obj);
    void RemoveContent(Object obj);
}

public interface IConsumeable
{
    void Consume();
}

public interface IExecutable
{
    void Execute();
}

public interface IInteractor
{
    void Interaction_Set(IInteractable interactable);
    void Interaction_Release();
}

public interface IInteractable
{
    void Interact(object token);
}

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
