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
            var container = sender.GetComponent<ContainerBehaviour>();

            if (Input.GetKeyDown(KeyCode.F))
            {
                var contents = container.GetItems();

                Debug.Log("Before Contents");
                foreach (Item item in contents)
                {
                    Debug.Log(item.name);                    
                }

                inventory.AddContent(contents[2]);
                container.RemoveItem(contents[2]);
                Debug.Log("Taken " + contents[2].Name + " from " + sender.name);

                Debug.Log("After Contents");
                foreach (Item item in contents)
                {
                    Debug.Log(item.name);
                }
            }            
        }
    }
}
