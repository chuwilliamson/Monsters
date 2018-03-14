using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterInformation : ScriptableObject
{
    public StringVariable Name;

    public IntegerVariable BraveLevel;
    public IntegerVariable XP;

    public FloatVariable Strength;
    public FloatVariable Speed;
    public FloatVariable Sneak;
    public FloatVariable Health;
    public FloatVariable Fear;
}
