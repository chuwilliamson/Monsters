using UnityEngine;

public interface IListener
{
    void OnEventRaised(Object[] args);
    void Subscribe();
    void Unsubscribe();
}