using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class FearBeaviour : MonoBehaviour
{
    public Slider fear;
    public CharacterInfo character;
    public Animation runaway;


    void Afraid()
    {
        bool toAfraid = false;

        character.Fear += 1;

        if (character.Fear >= character.BraveLevel)
        {
            toAfraid = true;
            character.Fear = 100;
        }

        if (toAfraid == true)
        {
            //runaway.SetTrigger("Run");
            SceneManager.LoadScene("2.SafeHouse");
            if (character.Fear == 0)
            {
                toAfraid = false;
            }
        }
    }
    // Use this for initialization
    void Start ()
    {
        character.Fear = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        fear.value = character.Fear;
        fear.maxValue = character.BraveLevel;
        fear.minValue = 0;
        
        Afraid();	
	}
}
