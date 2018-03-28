using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventoryBehaviour : MonoBehaviour
{
    public Canvas inventory;
    public GameEventArgs ButtonCLickEvent;

    List<Item> PlayerList = new List<Item>();

    private void Start()
    {
        inventory.enabled = false;
        Time.timeScale = 1.0f;
    }

    public void OnInvetoryOpened(params Object[] args)
    {
        PlayerList = new List<Item>();

        var data = args[0] as ContainerEventData;

        foreach (Item i in data.Data)
            PlayerList.Add(i);

      
    }
    
    public void Equip(params Object[] args)
    {


    }

    private void Update()
    {
        if (Input.GetButtonDown("ViewButton") && inventory.enabled == false)
        {
            inventory.enabled = true;

            var button = Resources.Load("Prefabs/ItemButton") as GameObject;
            var pic = Resources.Load("Prefabs/ItemPic") as GameObject;

            for (int i = PlayerList.Capacity; i < PlayerList.Capacity; i++)
                ;


            EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("Equipped"));

            Instantiate(pic, new Vector3(inventory.transform.position.x + 33, inventory.transform.position.y + 30, inventory.transform.position.z), inventory.transform.rotation, inventory.transform);
        }

    }
}
