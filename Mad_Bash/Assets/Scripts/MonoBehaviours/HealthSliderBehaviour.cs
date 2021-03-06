﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private CharacterInformation character;

    [SerializeField]
    private Slider Health;

	// Use this for initialization
	void Start ()
    {
        Health.minValue = 0.0f;
        Health.maxValue = character.Health.Value;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    Health.value = character.Health.Value;
    }
}
