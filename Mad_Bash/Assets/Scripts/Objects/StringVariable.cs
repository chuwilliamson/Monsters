using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringVariable : ScriptableObject
{
    [SerializeField]
    private string value;

    public string Value
    {
        get
        {
            return value;
        }   
    }
}
