using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    
    [SerializeField]
    ButtonPressContext _buttonPressContext;

    public GameEventArgsResponse Response;
    private Animator _anim;

    public void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void OnContextFinished(Object[] args)
    {
        if (_buttonPressContext.TotalScore >= 3)
            Response.Invoke(args);
    }

    
}
