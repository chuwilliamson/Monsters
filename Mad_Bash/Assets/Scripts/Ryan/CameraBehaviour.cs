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
        float transX = transform.rotation.x;
        float transY = transform.rotation.y;
        float transZ = transform.rotation.z;
        float transW = transform.rotation.w;

        character.transform.rotation = new Quaternion(transY, transX, transZ, transW);
        //transform.position = character.transform.position + new Vector3(0,2,-5);
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        rotX -= mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -25, 25);

        float moveCRX = character.transform.rotation.x + rotX;
        float moveCRY = character.transform.rotation.y + rotY;
        
        transform.rotation = Quaternion.Euler(rotX, rotY, 0.0f);

        transform.position = character.transform.position /*+ new Vector3(0, 2.5f, -5)*/;
        
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
