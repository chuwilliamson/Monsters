using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(GameEventArgsListener))]
[DisallowMultipleComponent]
public class CabinentBehaviour : MonoBehaviour 
{
	[SerializeField]
	ButtonPressContext _buttonPressContext;

	private Animator _Anim;

	public void OnContextFinished(Object[] args)
	{
        if (_buttonPressContext.TotalScore >= 3)
        {
            _Anim.SetTrigger("Open");
        }
	}

	// Use this for initialization
	void Start()
	{
		_Anim = GetComponent<Animator>();
	}
}