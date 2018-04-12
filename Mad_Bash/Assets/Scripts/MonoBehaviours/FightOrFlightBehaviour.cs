using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class FightOrFlightBehaviour : MonoBehaviour
{
    public List<string> buttons;

    public string currentButton;

    public float grade;

    TimerBehaviour timer = new TimerBehaviour();

    private void OnEnable()
    { 
    }

    private void Start()
    {        
        buttons = new List<string>() { "A Button", "B Button", "X Button", "Y Button"};
    }

    private void Update()
    {
        if (Input.GetButtonDown(currentButton))
        {
        }
        
        ChooseButton();
    }

    public void ChooseButton()
    {
        currentButton = buttons[Random.Range(0, buttons.Count - 1)];
    }
}
