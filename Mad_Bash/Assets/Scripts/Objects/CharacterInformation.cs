using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterInformation : ScriptableObject
{
    public StringVariable Name;

    public IntegerVariable BraveryLevel;
    public IntegerVariable XP;

    public FloatVariable Strength;
    public FloatVariable Speed;
    public FloatVariable CurrentSpeed;
    public FloatVariable Sneak;
    public FloatVariable Health;
    public FloatVariable Fear;
}
