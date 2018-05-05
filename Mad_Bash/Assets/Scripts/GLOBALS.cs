using System.Collections.Generic;
using UnityEngine;
 
public interface IContainer
{
    bool AddContent(Object obj);
    bool RemoveContent(Object obj);
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
    void SetInteraction(IInteractable interactable);
    void ReleaseInteraction(IInteractable interactable);
}

public interface IInteractable
{
    void Interact(object token);
}

public interface IState
{
    void OnEnter(IContext context);
    void UpdateState(IContext context);
    void OnExit(IContext context);
}

public interface IContext
{
    void ResetContext();
    IState CurrentState { get; }
    void UpdateContext();
    void ChangeState(IState next);
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

public static class RandomRectPos
{
    public static Vector3 RandomOnRect(float areaX, float areaY)
    {
        float newX = Random.Range(-(areaX * 0.5f), (areaX * 0.5f));
        float newY = Random.Range(-(areaY * 0.5f), (areaY * 0.5f));        

        var vec3 = new Vector3(newX, newY);

        return vec3;
    }

    public static Vector3 RandomOnRect(float areaX, float areaY, float areaZ)
    {
        float newX = Random.Range(-(areaX * 0.5f), (areaX * 0.5f));
        float newY = Random.Range(-(areaY * 0.5f), (areaY * 0.5f));
        float newZ = Random.Range(-(areaZ * 0.5f), (areaZ * 0.5f));

        var vec3 = new Vector3(newX, newY, newZ);

        return vec3;
    }
}
