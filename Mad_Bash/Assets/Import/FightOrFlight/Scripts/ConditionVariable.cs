using UnityEngine;

public abstract class ConditionVariable : ScriptableObject
{
    public abstract bool Result { get; }
}