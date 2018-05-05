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

    private float accel;
    void Update()
    { 
        var h = Input.GetAxis(Horizontal.Value);
        var v = Input.GetAxis(Vertical.Value); 
        var move = new Vector2(h,v);
        accel = move.magnitude > 0 ? accel + Time.deltaTime : accel - Time.deltaTime;
        accel = Mathf.Clamp(accel, 0, 1);
        if (controller.isGrounded)
        {
     
            var forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            /*such copy paste but it works*/
            var right = new Vector3(forward.z, 0, -forward.x);
            targetDir = h * right + v * forward;
            if (targetDir.magnitude > Mathf.Epsilon)
                transform.rotation = Quaternion.LookRotation(targetDir);

            moveDirection = targetDir.normalized;
        }

        controller.SimpleMove(moveDirection * (character.Speed.Value * accel));
        character.CurrentSpeed.Value = controller.velocity.magnitude;
    }
}