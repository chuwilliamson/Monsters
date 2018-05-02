using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(GameEventArgsListener))]
[DisallowMultipleComponent]
public class DoorBehaviour : MonoBehaviour
{
    ButtonPressContext _buttonPressContext;
    public string DoorOpen = "open";
    private Animator doorAnim;

    public void OnContextFinished(Object[] args)
    {
        if (_buttonPressContext.TotalScore > 3)
        {
            doorAnim.SetTrigger(DoorOpen);
        }
    }
    
    // Use this for initialization
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }
}
