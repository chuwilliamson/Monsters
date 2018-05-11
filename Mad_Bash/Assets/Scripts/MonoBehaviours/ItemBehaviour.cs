using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour, IPhysicsTriggerEnterHandler
{
    // fields
    public Item Item;

    public Container Container
    {
        get { return Resources.Load("PlayerContainer") as Container; }
    }

    [SerializeField]
    private GameEventArgs ItemPickedUp;

    public void OnPhysicsTriggerEnter(Object[] args)
    {
        Container.AddContent(obj: Item);
        ItemPickedUp.Raise(Item);
        Destroy(obj: gameObject);
    }
}
