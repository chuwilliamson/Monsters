using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyssaTaylorAnimatorBehaviour : MonoBehaviour, IInteractionBeginHandler
{

    public static readonly int SPEED = Animator.StringToHash("Speed");
    public static readonly int ATTACK = Animator.StringToHash("Attack");
    public static readonly int OPEN = Animator.StringToHash("Open");
    public static readonly int INTERACT = Animator.StringToHash("Interact");
    public static readonly int HEALTH = Animator.StringToHash("Health");
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
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _anim.SetFloat(SPEED, _CurrentSpeed.Value/_Speed.Value);
        _anim.SetFloat(HEALTH, _Health.Value);
    }
    
    public void OnInteractionBegin(Object[] args)
    {
        _anim.SetTrigger(INTERACT);
    }
}
