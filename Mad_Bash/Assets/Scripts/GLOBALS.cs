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

public interface IInteractable
{
    void Iteract();
}