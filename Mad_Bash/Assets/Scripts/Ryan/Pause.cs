using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    protected bool paused;

    private void OnApplicationPause(bool pause)
    {
        pause = true;
        paused = pause;
    }

    void Paused()
    {
        if (Input.GetButton("Pause"))
            OnApplicationPause(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Paused();
	}
}
