using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FearBeaviour : MonoBehaviour
{
    public Slider fear;
    public CharacterInformation character;
    public Animation runaway;


    void Afraid()
    {
        bool toAfraid = false;

        character.Fear.Value += 1;

        if (character.Fear.Value >= character.BraveryLevel.Value)
        {
            toAfraid = true;
            character.Fear.Value = 100;
        }

        if (toAfraid == true)
        {
            //runaway.SetTrigger("Run");
            SceneManager.LoadScene("2.SafeHouse");
            if (character.Fear.Value == 0)
            {
                toAfraid = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        fear.value = character.Fear.Value;
        fear.maxValue = character.BraveryLevel.Value;
        fear.minValue = 0;
        
        Afraid();	
	}
}
