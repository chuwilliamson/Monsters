using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ButtonBehaviour : MonoBehaviour
{
    public GameEventArgs ButtonCLickEvent;
    public Canvas canvas;
    Dropdown characters;

    /// <summary>
    /// this is only
    /// to make the pause 
    /// menu
    /// </summary>
    void Start()
    {
        Time.timeScale = 1.0f;
        canvas.enabled = false;
    }

    public void ChangeSceneEvent(string name)
    {
        ButtonCLickEvent.Raise();
        SceneManager.LoadScene(name);   
    }

    public void Paused()
    {
        if (Input.GetButton("MenuButton"))
        {
            canvas.enabled = true;
            Time.timeScale = 0.0f;
            EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("Continue"));
        }
    }
    public void Continue()
    {
        canvas.enabled = false;
        Time.timeScale = 1.0f;
        EventSystem.current.SetSelectedGameObject(null);
    }
    //////////////////////////////////////////////////////////////////////////////


    ///<summary>
    ///this will be for inventory
    ///</summary>
    
    
    
    //////////////////////////////////////////////////////////////////////////////



    ///<summary>
    ///this will be for the safe house
    ///</summary>
    
    public void SelectCharacters()
    {
        Instantiate(characters);
        characters.value = 4;
         
    }




    void Update()
    {
        Paused();
    }
}
