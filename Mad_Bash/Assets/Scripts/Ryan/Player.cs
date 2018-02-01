using Ryan;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Animator dooropener;
    public GameObject Door;
    Consumable help;
    Distraction distract;
    KeyItems keyItem;
    Ryan.Item item;
    
    public CharacterInfo character;


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

    public void DoorControl()
    {
        if (Input.GetButtonDown("Interact") && Vector3.Distance(transform.position, Door.transform.position) < 3)
            dooropener.SetTrigger("open");

    }


    void ItemPickUp()
    {
        if (Input.GetButtonDown("Interact") && Vector3.Distance(transform.position, weapon.item.transform.position) < 2)
            weapon.item.transform.position = transform.position;
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
        DoorControl();
        ItemPickUp();
    }
}
