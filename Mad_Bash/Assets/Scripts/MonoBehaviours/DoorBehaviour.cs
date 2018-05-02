using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(GameEventArgsListener))]
[DisallowMultipleComponent]
public class DoorBehaviour : MonoBehaviour
{
    [SerializeField]
    ButtonPressContext _buttonPressContext;
    public string DoorOpen = "opneing";
    public string DoorClosed = "Naw Son";
    private Animator _Anim;

    public void OnContextFinished(Object[] args)
    {
        if (_buttonPressContext.TotalScore >= 3)
        {
            _Anim.SetTrigger("Interact");
            Debug.Log(DoorOpen);
        }
        else
            Debug.Log(DoorClosed);
    }
    
    // Use this for initialization
    void Start()
    {
        _Anim = GetComponent<Animator>();
    }
}
