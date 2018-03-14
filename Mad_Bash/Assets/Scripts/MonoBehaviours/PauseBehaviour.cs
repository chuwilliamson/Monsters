using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ryan

public class PauseBehaviour : MonoBehaviour
{
    public Canvas canvas;

    GUI.WindowFunction pauseMenu;
    Rect MainMenu;

    public void Paused()
    {
        if (Input.GetButton("MenuButton"))
        {
            canvas.enabled = true;
            Time.timeScale = 0.0f;
        }
    } 
    public void Continue()
    {
        canvas.enabled = !canvas.enabled;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        canvas.enabled = !canvas.enabled;
    }

    // Update is called once per frame
    void Update ()
    {
        Paused();
    }
}
