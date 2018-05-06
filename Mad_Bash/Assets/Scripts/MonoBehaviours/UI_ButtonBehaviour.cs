using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_ButtonBehaviour : MonoBehaviour
{
    public GameEventArgs ButtonCLickEvent;
    private CharacterInformation character;
    public Canvas inventory;

    [SerializeField] private GameEventArgsListener InventoryClosed;

    [SerializeField] private GameEventArgsListener InventoryOpened;

    public List<Item> PlayerItems;

    public Canvas puase;

    /// <summary>
    ///     this is only
    ///     to make the pause
    ///     menu
    /// </summary>
    private void Start()
    {
        Time.timeScale = 1.0f;
        puase.enabled = false;
        inventory.enabled = false;

        character = Instantiate(
            original: Resources.Load("ScriptableObjects/Characters/Alyassa") as CharacterInformation);

        //PlayerItems.Capacity = (int)character.Strength.Value;
    }

    public void ChangeSceneEvent(string name)
    {
        ButtonCLickEvent.Raise();
        SceneManager.LoadScene(name);
    }

    private void Paused()
    {
        if (Input.GetButton("MenuButton") && inventory.enabled == false)
        {
            puase.enabled = true;
            Time.timeScale = 0.0f;
            EventSystem.current.SetSelectedGameObject(selected: GameObject.FindGameObjectWithTag("Continue"));
        }
    }

    public void Continue()
    {
        puase.enabled = false;
        Time.timeScale = 1.0f;
        EventSystem.current.SetSelectedGameObject(null);
    }
    //////////////////////////////////////////////////////////////////////////////


    /// <summary>
    ///     this will be for inventory
    /// </summary>
    public void OnInvetoryOpened(params Object[]args)
    {
        ButtonCLickEvent.Raise(InventoryOpened);

        inventory.enabled = true;
        Time.timeScale = 0.0f;

        var button = Resources.Load("Prefabs/ItemButton") as GameObject;

        var pic = Resources.Load("Prefabs/ItemPic") as GameObject;

        foreach (var i in PlayerItems)
            Instantiate(button,
                position: new Vector3(x: inventory.transform.position.x - 45, y: inventory.transform.position.y + 30,
                    z: inventory.transform.position.z), rotation: inventory.transform.rotation,
                parent: inventory.transform);

        //button.GetComponent<Text>().text = i.Name;

        EventSystem.current.SetSelectedGameObject(selected: GameObject.FindGameObjectWithTag("Equipped"));

        Instantiate(pic,
            position: new Vector3(x: inventory.transform.position.x + 33, y: inventory.transform.position.y + 30,
                z: inventory.transform.position.z), rotation: inventory.transform.rotation,
            parent: inventory.transform);

        Debug.Log("fired");
    }

    private void ViewTheStuff()
    {
        if (Input.GetButtonDown("ViewButton") && puase.enabled == false && inventory.enabled == false)
            OnInvetoryOpened();
    }


    private void GameContinue()
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


    /// <summary>
    ///     this will be for the safe house
    /// </summary>
    private void Update()
    {
        Paused();
        ViewTheStuff();
        GameContinue();
    }
}