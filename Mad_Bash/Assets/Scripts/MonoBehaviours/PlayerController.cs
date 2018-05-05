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

    public float moveSpeed = 0.0f;

    public Vector3 moveDirection;
    public Vector3 targetDirection;

    private CharacterController controller;
    public float rotateSpeed = 250.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public bool turning = false;
    public float dot;

    void Update()
    {
    
        var forward = Camera.main.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        /*such copy paste but it works*/
        var right = new Vector3(forward.z, 0, -forward.x);

        var h = Input.GetAxis(Horizontal.Value);
        var v = Input.GetAxis(Vertical.Value);
        var input = new Vector2(h, v);
 
        targetDirection = h * right + v * forward; 

        if (controller.isGrounded)
        {
            if (targetDirection.magnitude >= Mathf.Epsilon)
            {
                moveDirection = Vector3.RotateTowards(
                    moveDirection,
                    targetDirection,
                    rotateSpeed * Mathf.Deg2Rad * Time.deltaTime,
                    1000);

                dot = Vector3.Dot(moveDirection.normalized, targetDirection.normalized);

                turning = dot < .95;

                moveDirection = moveDirection.normalized;  
                 
                transform.rotation = Quaternion.LookRotation(moveDirection);
 

            }
        }
        
        if (input.magnitude > Mathf.Epsilon && !turning)
        {
            
            controller.SimpleMove(moveDirection * character.Speed.Value);
            character.CurrentSpeed.Value = controller.velocity.magnitude; 
          
        }
        else
        {
        
            character.CurrentSpeed.Value = 0;
        } 
    }

    public CollisionFlags flags;
}