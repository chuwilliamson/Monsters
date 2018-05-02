using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyssaTaylorAnimatorBehaviour : MonoBehaviour, IInteractionBeginHandler
{

    public static readonly int SPEED = Animator.StringToHash("HorizontalSpeed");
 
    [SerializeField]
    private Animator _anim;
    [SerializeField]
    private FloatVariable _Speed;
    [SerializeField]
    private FloatVariable _CurrentSpeed;
    [SerializeField]
    private FloatVariable _Health;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _anim.SetFloat(SPEED, _CurrentSpeed.Value/_Speed.Value); 
    }
    
    public void OnInteractionBegin(Object[] args)
    { 
    }
}
