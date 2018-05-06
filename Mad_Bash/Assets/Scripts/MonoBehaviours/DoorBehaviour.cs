using UnityEngine;

[RequireComponent(typeof(Animator), typeof(GameEventArgsListener))]
[DisallowMultipleComponent]
public class DoorBehaviour : ContextResolutionBehaviour
{ 
    private Animator _Anim; 
}
