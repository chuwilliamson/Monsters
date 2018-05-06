using UnityEngine;

namespace Cinemachine.Examples
{
    [AddComponentMenu("")] // Don't display in add component menu
    public class CharacterMovement : MonoBehaviour,ICharacterMovement
    {
        private Animator anim;
        private float direction;
        private Quaternion freeRotation;
        private Vector2 input;
        private bool isSprinting;
        public bool keepDirection;
        private Camera mainCamera;
        private float speed;
        public KeyCode sprintJoystick = KeyCode.JoystickButton2;
        public KeyCode sprintKeyboard = KeyCode.Space;
        private Vector3 targetDirection;
        public float turnSpeed = 10f;

        private float turnSpeedMultiplier;
        private float velocity;

        // Use this for initialization
        private void Start()
        {
            anim = GetComponent<Animator>();
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            // set speed to both vertical and horizontal inputs
            if (keepDirection) speed = Mathf.Abs(input.x) + input.y;
            else speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);

            speed = Mathf.Clamp(speed, 0f, 1f);
            speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref velocity, 0.1f);
            anim.SetFloat("Speed", speed);

            if (input.y < 0f && keepDirection) direction = input.y;
            else direction = 0f;

            anim.SetFloat("Direction", direction);


            // set sprinting
            if ((Input.GetKeyDown(sprintJoystick) || Input.GetKeyDown(sprintKeyboard)) && input != Vector2.zero &&
                direction >= 0f) isSprinting = true;
            if (Input.GetKeyUp(sprintJoystick) || Input.GetKeyUp(sprintKeyboard) || input == Vector2.zero)
                isSprinting = false;
            anim.SetBool("isSprinting", isSprinting);

            // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
            UpdateTargetDirection();
            if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
            {
                var lookDirection = targetDirection.normalized;
                freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
                var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
                var eulerY = transform.eulerAngles.y;

                if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
                var euler = new Vector3(0, eulerY, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler),
                    turnSpeed * turnSpeedMultiplier * Time.deltaTime);
            }
        }

        public virtual void UpdateTargetDirection()
        {
            if (!keepDirection)
            {
                turnSpeedMultiplier = 1f;
                var forward = mainCamera.transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = mainCamera.transform.TransformDirection(Vector3.right);

                // determine the direction the player will face based on input and the referenceTransform's right and forward directions
                targetDirection = input.x * right + input.y * forward;
            }
            else
            {
                turnSpeedMultiplier = 0.2f;
                var forward = transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = transform.TransformDirection(Vector3.right);
                targetDirection = input.x * right + Mathf.Abs(input.y) * forward;
            }
        }

        public void Disable(object sender)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Animator>().applyRootMotion = false;
        }

        public void Enable(object sender)
        {
            GetComponent<Animator>().applyRootMotion = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}