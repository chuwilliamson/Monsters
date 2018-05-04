using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Matthew
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour
{
    public StringVariable Horizontal;
    public StringVariable Vertical;

    [SerializeField]
    public CharacterInformation character;

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
        character.CurrentSpeed.Value = controller.velocity.magnitude;

        var h = Input.GetAxisRaw(Horizontal.Value);
        var v = Input.GetAxisRaw(Vertical.Value);


        if (controller.isGrounded)
        {
     
            var forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            ///such copy paste but it works
            var right = new Vector3(forward.z, 0, -forward.x);
            targetDir = h * right + v * forward;
            if (targetDir.magnitude > Mathf.Epsilon)
                transform.rotation = Quaternion.LookRotation(targetDir);

            moveDirection = targetDir;
        }

        controller.SimpleMove(moveDirection * character.Speed.Value);
        character.CurrentSpeed.Value = controller.velocity.magnitude;
    }
}