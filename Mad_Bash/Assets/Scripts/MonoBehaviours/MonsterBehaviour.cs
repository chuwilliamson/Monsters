using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    public GameObject character;

    public float speed;
    public float strength;


    void FindCharacter()
    {

    }

    void Attack()
    {

    }

	void Start ()
    {
        speed = GetComponent<MonsterInformation>().Speed.Value;
        strength = GetComponent<MonsterInformation>().Strength.Value;
	}
	
	void Update ()
    {
		
	}
}
