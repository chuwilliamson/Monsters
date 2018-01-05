using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterInfo : ScriptableObject
{
    public int _level = 1, _xp = 0, _pow, _int;

    public float _speed, _bravness, _presence, _health, _fear = 0; 
}
