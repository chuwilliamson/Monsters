using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ButtonBehaviour : MonoBehaviour {

    public GameEventArgs ButtonCLickEvent;
    
    public void RaiseTheEvent()
    {
        ButtonCLickEvent.Raise();
    }
}
