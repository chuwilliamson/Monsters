using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject player;

    public float mouseSensitivity = 100;

    float rotX;
    float rotY;

    Vector3 offsetX;
    Vector3 offsetY;

    private void Start()
    {
        offsetX = new Vector3(player.transform.position.x, player.transform.position.y + 8, player.transform.position.z + 7);
        offsetY = new Vector3(0, 0, player.transform.position.z + 7);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update ()
    {
        player.transform.rotation = transform.rotation;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotY += mouseX /** mouseSensitivity * Time.deltaTime*/;

        rotX -= mouseY /** mouseSensitivity * Time.deltaTime*/;

        //rotX = Mathf.Clamp(rotX, -25, 25);

        offsetX = Quaternion.AngleAxis(-mouseX, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(-mouseY, Vector3.right) * offsetY;

        transform.position = player.transform.position + (offsetX + offsetY);
        transform.LookAt(player.transform.position);

        if (Input.GetButtonDown(""))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButtonUp(""))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(Input.GetButton(""))
        {
            transform.rotation = player.transform.rotation;
        }
    }
}
