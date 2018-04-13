using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSequence : MonoBehaviour
{    
    public List<ButtonPressObject> buttons;
    public ButtonPressObject currentButton;
    public float passingScore = .6f;
    public bool win = false;

    private void Start()
    {
        NextButton();
    }

    private void Update()
    {
        currentButton.ButtonPressLogic();
    }

    public void NextButton()
    {
        currentButton = buttons[Random.Range(0, buttons.Count - 1)];
    }

    public void PassOrFail()
    {
        var totalScore = 0;

        foreach (ButtonPressObject b in buttons)
            totalScore += b.score;

        if (totalScore >= passingScore)
            win = true;
    }
}
