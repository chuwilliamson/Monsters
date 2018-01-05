using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterInfo character;
    public GameObject _camera;

    float horizontal = 1;
    float vertical = 1;

	// Use this for initialization
	void Start ()
    { 
        transform.position = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position += new Vector3(0, -9.81f, 0) * Time.deltaTime

        transform.forward = _camera.transform.forward;
        transform.rotation = _camera.transform.rotation;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float xpos = (horizontal * character._speed) * transform.forward.magnitude;
        float zpos = vertical * character._speed;

        Vector3 forward = (new Vector3(0, 0, zpos) * Time.deltaTime);

        Vector3 sprint = (forward * 3);
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            transform.position += sprint;
        }

        transform.position += new Vector3(xpos, 0, zpos) * Time.deltaTime; 
    }
}
