using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterInfo character;

    public int level, xp, intellegence, power;
    public float speed, health, brave, weight, fear;

    bool dead = false;
    
    void Update()
    {
        level = character._level;
        xp = character._xp;
        intellegence = character._int;
        power = character._pow;
        speed = character._speed;
        health = character._health;
        brave = character._bravness;
        weight = character._presence;
        fear = character._fear;


        if (character._health <= 0)
            dead = true;

        if (dead == true)
        {
            power = 0;
            speed = 0;
        }
    }
}
