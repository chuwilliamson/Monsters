using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionVariable : ScriptableObject
{
    public abstract bool Result { get; }
}