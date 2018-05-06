using UnityEngine;

//Matthew
[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour, ICharacterMovement
{
    [SerializeField] public CharacterInformation character;

    private CharacterController controller;
    public float dot;
    public StringVariable Horizontal;

    public Vector3 moveDirection;

    public float moveSpeed;
    public float rotateSpeed = 250.0f;
    public Vector3 targetDirection;

    public bool turning;
    public StringVariable Vertical;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
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
            if (targetDirection.magnitude >= Mathf.Epsilon)
            {
                moveDirection = Vector3.RotateTowards(moveDirection, targetDirection,
                    rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);

                dot = Vector3.Dot(moveDirection.normalized, targetDirection.normalized);

                turning = dot < .95;

                moveDirection = moveDirection.normalized;

                transform.localRotation = Quaternion.LookRotation(moveDirection);
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

    public void Disable(object sender)
    {
        this.enabled = false;
        character.CurrentSpeed.Value = 0.0f;
    }

    public void Enable(object sender)
    {
        this.enabled = true;
    }
}