using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBehaviour : MonoBehaviour
{
    public Container inventory;
    public Item itemInHand;
    public int health;

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

    public void OpenContainer(UnityEngine.Object[] args)
    {
        var sender = args[0] as GameObject;
        var collidedwith = args[1];
        if (collidedwith != gameObject)
            return;

        if (sender != null)
        {
            var containerBehaviour = sender.GetComponent<ContainerBehaviour>();
            var items = containerBehaviour.Container.contents;

            if (Input.GetKeyDown(KeyCode.F))
            {
                containerBehaviour.Open();
                Debug.Log("open");
            }            
        }
    }
}
