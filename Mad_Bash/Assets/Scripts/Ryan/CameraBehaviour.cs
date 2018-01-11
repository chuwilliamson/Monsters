using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject character;

    public float mouseSensitivity = 100;

    float rotX;
    float rotY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update ()
    {
        //transform.position = character.transform.position + new Vector3(0,2,-5);

        character.transform.rotation = transform.rotation;
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        rotX -= mouseY * mouseSensitivity * Time.deltaTime;


        rotX = Mathf.Clamp(rotX, -25, 25);
        rotY = Mathf.Clamp(rotY, -50, 50);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f);

        transform.position = character.transform.position + new Vector3(0, 2.5f, -5);

        if (Input.GetKey(KeyCode.JoystickButton9))
        {
            transform.forward = character.transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button6) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button6) || Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
