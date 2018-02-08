using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterInfo character;
    public GameObject _camera;
    public GameObject Door;
    public Animator dooropener;

    float h;
    float v;

	// Use this for initialization
	void Start ()
    {
        //transform.position = new Vector3(0, 0, 0);
    }

    public void DoorControl()
    {
        if (Input.GetButtonDown("Interact") && Vector3.Distance(transform.position, Door.transform.position) < 3)
            dooropener.SetTrigger("open");
    }

    void Move()
    {

        h = Input.GetAxis("Horizontal") * character._speed;
        v = Input.GetAxis("Vertical") * character._speed;

        h *= Time.deltaTime;
        v *= Time.deltaTime;

        Vector3 sprint = transform.forward;

        if (Input.GetKey(KeyCode.LeftShift) && v >= .01f || (Input.GetKey(KeyCode.JoystickButton7) && v >= .01f))
        {
            transform.position += (sprint / 3);
        }

        transform.Translate(h, 0, v);
    }

    // Update is called once per frame
    void Update ()
    {
        Move();
        DoorControl();
    }
}
