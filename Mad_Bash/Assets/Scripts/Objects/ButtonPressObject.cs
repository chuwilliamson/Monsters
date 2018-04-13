using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressObject : ScriptableObject
{
    public string inputName;
    public float TimeToLive = 1f;
    public float TimeToPress = 0.5f;
    public int score;
    public bool buttonPressed;

    public void ButtonPressLogic()
    {
        if (Input.GetButtonDown(inputName))
            buttonPressed = true;

        if (TimeToLive <= 0)
            buttonPressed = false;

        if (buttonPressed && TimeToPress > 0)
            score = 1;
        else
            score = 1;

        TimeToLive -= Time.deltaTime;
        TimeToPress -= Time.deltaTime;
    }
}
