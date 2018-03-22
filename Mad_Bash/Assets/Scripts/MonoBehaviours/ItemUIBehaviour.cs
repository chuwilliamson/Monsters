using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIBehaviour : MonoBehaviour
{
    // fields
    [SerializeField]
    private Text itemName;
    
    // Unity methods
    private void Start()
    {   
        itemName.text = "No Item.";
    }

    // methods
    public void OnItemPickUp(params Object[] args)
    {
        var item = args[0] as Item;
        itemName.text = "Picked up " + item.Name.ToString();
    }
}
