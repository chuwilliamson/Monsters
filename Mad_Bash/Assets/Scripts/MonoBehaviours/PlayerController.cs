using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Matthew

public class PlayerController : MonoBehaviour
{
    public StringVariable Horizontal;
    public StringVariable Vertical;

    [SerializeField]
    private CharacterInformation character;
     

    public float gravity = 20.0F;

    private Vector3 moveDirection;
    private CharacterController controller;
    [ReadOnly]
    public Vector3 targetDir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        character = GetComponent<PlayerObjectBehaviour>().CharacterInfo;

        if (controller.isGrounded)
        {
            var h = Input.GetAxis(Horizontal.Value);
            var v = Input.GetAxis(Vertical.Value);
            var forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            ///such copy paste but it works
            var right = new Vector3(forward.z, 0, -forward.x);
            targetDir = h * right + v * forward;
            if (targetDir.magnitude > 0)
                transform.rotation = Quaternion.LookRotation(targetDir);

            moveDirection = targetDir;
        }

        controller.SimpleMove(moveDirection * character.Speed.Value);
        character.CurrentSpeed.Value = controller.velocity.magnitude;
    }
}