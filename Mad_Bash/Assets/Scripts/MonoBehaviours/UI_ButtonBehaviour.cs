using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ButtonBehaviour : MonoBehaviour
{
    CharacterInformation character;

    public Canvas puase;
    public Canvas inventory;

    public List<Item> PlayerItems;

    public GameEventArgs ButtonCLickEvent;
    
    GameEventArgsListener InventoryOpened;
    GameEventArgsListener InventoryClosed;
    
    /// <summary>
    /// this is only
    /// to make the pause 
    /// menu
    /// </summary>
    void Start()
    {
        Time.timeScale = 1.0f;
        puase.enabled = false;
        inventory.enabled = false;

        character = Instantiate(Resources.Load("ScriptableObjects/Characters/Alyassa") as CharacterInformation);

        //PlayerItems.Capacity = (int)character.Strength.Value;
    }

    public void ChangeSceneEvent(string name)
    {
        ButtonCLickEvent.Raise();
        SceneManager.LoadScene(name);   
    }

    void Paused()
    {
        if (Input.GetButton("MenuButton") && inventory.enabled == false)
        {
            puase.enabled = true;
            Time.timeScale = 0.0f;
            EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("Continue"));
        }
    }

    public void Continue()
    {
        puase.enabled = false;
        Time.timeScale = 1.0f;
        EventSystem.current.SetSelectedGameObject(null);
    }
    //////////////////////////////////////////////////////////////////////////////


    ///<summary>
    ///this will be for inventory
    ///</summary>
    public void OnInvetoryOpened(params Object []args)
    {
        ButtonCLickEvent.Raise(InventoryOpened);

        inventory.enabled = true;
        Time.timeScale = 0.0f;

        var button = Resources.Load("Prefabs/ItemButton") as GameObject;

        var pic = Resources.Load("Prefabs/ItemPic") as GameObject;
        
        foreach (Item i in PlayerItems)
        {
            Instantiate(button, new Vector3(inventory.transform.position.x - 45, inventory.transform.position.y + 30, inventory.transform.position.z), inventory.transform.rotation, inventory.transform);

            //button.GetComponent<Text>().text = i.Name;
        }

        EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("Equipped"));
        
        Instantiate(pic, new Vector3(inventory.transform.position.x + 33, inventory.transform.position.y + 30, inventory.transform.position.z), inventory.transform.rotation, inventory.transform);
        
        Debug.Log("fired");
    }

    void ViewTheStuff()
    {
        if (Input.GetButtonDown("ViewButton") && puase.enabled == false && inventory.enabled == false)
            OnInvetoryOpened();
    }


    void GameContinue()
    {
        if (Input.GetButtonDown("B Button"))
        {
            inventory.enabled = false;
            puase.enabled = false;
            Time.timeScale = 1.0f;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }
    //////////////////////////////////////////////////////////////////////////////



    ///<summary>
    ///this will be for the safe house
    ///</summary>



    void Update()
    {
        Paused();
        ViewTheStuff();
        GameContinue();
    }
}
