using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{    
    public Item item_config;
    [SerializeField]
    private Item item_runtime;

    public Item Item
    {
        get { return Item; }
    }

    private void Start()
    {
        item_runtime = Instantiate(item_config);
    }
}
