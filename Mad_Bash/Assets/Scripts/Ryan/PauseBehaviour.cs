using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    public Canvas canvas;

    GUI.WindowFunction pauseMenu;
    Rect MainMenu;
    bool paused = false;

    public void Paused()
    {
        if (Input.GetButton("PauseMenu"))
        {
            paused = true;
            canvas.enabled = true;
            Time.timeScale = 0.0f;
        }
    } 
    public void Continue()
    {
        paused = false;
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
