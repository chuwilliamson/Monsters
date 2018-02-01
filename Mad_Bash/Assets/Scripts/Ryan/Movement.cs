using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterInfo character;
    public GameObject _camera;

    float horizontal;
    float vertical;

	// Use this for initialization
	void Start ()
    { 
        //transform.position = new Vector3(0, 0, 0);
    }

    void Move()
    {

        horizontal = Input.GetAxis("Horizontal") * character._speed;
        vertical = Input.GetAxis("Vertical") * character._speed;

        horizontal *= Time.deltaTime;
        vertical *= Time.deltaTime;

        Vector3 sprint = transform.forward;

        if (Input.GetKey(KeyCode.LeftShift) && vertical >= .01f || (Input.GetKey(KeyCode.JoystickButton7) && vertical >= .01f))
        {
            transform.position += (sprint / 3);
        }

        transform.Translate(horizontal, 0, vertical);
    }

    // Update is called once per frame
    void Update ()
    {
        Move();
    }
}
