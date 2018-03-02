using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBehaviour : MonoBehaviour
{
    public Container inventory;
    public int health;


    public void TakeItem(Object obj)
    {
        inventory.AddContent(obj);
    }

    public void DropItem(Object obj)
    {
        inventory.RemoveContent(obj);
    }

    public void TakeDamage()
    {
        health -= 10;
        Debug.Log("took damage");
    }

    public void TakeDamage(UnityEngine.Object[] args)
    {
        var sender = args[0];
        var collidedwith = args[1];
        if (collidedwith != gameObject)
            return;
        if(sender != null)
        {
            Debug.Log("taking damage from " + collidedwith.name);
            TakeDamage();
        }
    }
}
