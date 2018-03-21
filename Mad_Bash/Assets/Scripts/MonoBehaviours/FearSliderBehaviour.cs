using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearSliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private CharacterInformation character;

    [SerializeField]
    private Slider Fear;

	// Use this for initialization
	void Start ()
    {
        Fear.minValue = 0;
        Fear.maxValue = character.BraveryLevel.Value;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Fear.value = character.Fear.Value;	
	}
}
