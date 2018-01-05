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
    }

    // Update is called once per frame
    void Update ()
    {
       transform.position = character.transform.position + new Vector3(0,2,-5);
        
       transform.forward = character.transform.forward;

       float mouseX = Input.GetAxis("Mouse X");
       float mouseY = Input.GetAxis("Mouse Y");

       rotY += mouseX * mouseSensitivity * Time.deltaTime;
       rotX -= mouseY * mouseSensitivity * Time.deltaTime;

       transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f);

        if(Input.GetKey(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyUp(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
