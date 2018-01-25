using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ryan;
using Jeremy;


public class Player : MonoBehaviour
{
    Ryan.Weapon weapon;
    Ryan.Consumable help;
    Ryan.Distraction distract;
    Ryan.KeyItems keyItem;
    Ryan.Item item;
    
    public CharacterInfo character;

    protected bool paused;

    public int level, xp, intellegence, power;
    public float speed, health, brave, weight, fear;

    bool dead = false;

    void IsDead()
    {
        if (character._health <= 0)
            dead = true;

        if (dead == true)
        {
            power = 0;
            speed = 0;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        pause = true;
        paused = pause;
    }

    void Pause()
    {

    }

    void PickUp()
    {
        if (Input.GetButton("Fire1"))
            item.Pickup = true;

        if (item.Pickup == true)
        {
            item.transform.position = transform.position;
        }
    }
    
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

        IsDead();
        PickUp();

    }
}
