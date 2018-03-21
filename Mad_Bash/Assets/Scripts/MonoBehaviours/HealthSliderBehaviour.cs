using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSliderBehaviour : MonoBehaviour
{
    public Slider Health;


	// Use this for initialization
	void Start ()
    {
        Health.minValue = 0.0f;
        Health.maxValue = GetComponent<CharacterInformation>().Health.Value;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    Health.value = GetComponent<CharacterInformation>().Health.Value;
    }
}
