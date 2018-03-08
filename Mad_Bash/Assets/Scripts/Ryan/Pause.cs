using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Paused()
    {
        if (Input.GetButton("Pause"))
        {

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Paused();
	}
}
