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
