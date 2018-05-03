using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    GameObject character;
    [SerializeField]
    ButtonPressContext _buttonPressContext;
    private Animator _Anim;

    public void OnContextFinished(Object[] args)
    {
        if (_buttonPressContext.TotalScore >= 3)
        {
            Debug.Log("You Defeated The Monster, Plays Final Fantasy Music");
        }
        else
        {
            Debug.Log("You Dead Sorry");
        }
    }

	void Start ()
    {
        _Anim = GetComponent<Animator>();
	}

    void FindCharacter()
    {

    }

    void Attack()
    {

    }
}
