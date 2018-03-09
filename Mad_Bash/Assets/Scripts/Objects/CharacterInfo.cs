using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterInfo : ScriptableObject
{
    public float BraveLevel;
    public int XP = 0;
    public int Strength;

    public float Speed;
    public float Sneak;
    public float Health;
    public float Fear = 0;

    public FloatVariable SmallSpeed;
}
