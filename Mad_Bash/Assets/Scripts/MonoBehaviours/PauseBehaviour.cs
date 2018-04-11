using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBehaviour : MonoBehaviour
{
    public GameEventArgs ButtonClickEvent;

    CharacterInformation character;

    public Canvas puase;
    
    void Start()
    {
        Time.timeScale = 1.0f;
        puase.enabled = false;
    }

    public void ChangeSceneEvent(params Object[] args)
    {
        ButtonClickEvent.Raise(this);
        SceneManager.LoadScene("");
    }

    void Paused()
    {
        if (Input.GetButtonDown("MenuButton"))
        {
            puase.enabled = true;
            Time.timeScale = 0.0f;
            EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("Continue"));
        }
    }

    public void GameContinue(params Object[] args)
    {
        ButtonClickEvent.Raise(this);

        puase.enabled = false;
        Time.timeScale = 1.0f;
        EventSystem.current.SetSelectedGameObject(null);

        if (Input.GetButtonDown("B Button"))
        {
            puase.enabled = false;
            Time.timeScale = 1.0f;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    void Update()
    {
        Paused();
    }
}
