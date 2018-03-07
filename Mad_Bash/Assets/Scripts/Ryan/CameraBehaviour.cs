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

    public float height = 1, distance;

    private void Start()
    {
        offsetX = new Vector3(0, height, distance);
        offsetY = new Vector3(0, 0, distance);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void Update ()
    {
        player.transform.rotation = transform.rotation;
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        rotX -= mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -25, 25);

        offsetX = Quaternion.AngleAxis(rotY, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(rotX, Vector3.right) * offsetY;

        transform.position = player.transform.position + offsetX;
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
