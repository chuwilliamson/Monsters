using UnityEngine;

namespace Cinemachine.Examples
{
    [AddComponentMenu("")] // Don't display in add component menu
    public class CharacterMovement : MonoBehaviour, ICharacterMovement
    {
        private Animator _anim;
        private float _direction;
        private Quaternion _freeRotation;
        private Vector2 _input;
        private bool _isSprinting;
        private Camera _mainCamera;
        private float _speed;
        private Vector3 _targetDirection;

        private float _turnSpeedMultiplier;
        private float _velocity;
        public bool KeepDirection;
        public KeyCode SprintJoystick = KeyCode.JoystickButton2;
        public KeyCode SprintKeyboard = KeyCode.Space;
        public float TurnSpeed = 10f;

        public void Disable(object sender)
        {
            _anim.applyRootMotion = false;
        }

        public void Enable(object sender)
        {
            _anim.applyRootMotion = true;

        }

        // Use this for initialization
        private void Start()
        {
            _anim = GetComponent<Animator>();
            _mainCamera = Camera.main;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            _input.x = Input.GetAxis("Horizontal");
            _input.y = Input.GetAxis("Vertical");

            // set speed to both vertical and horizontal inputs
            if (KeepDirection) _speed = Mathf.Abs(_input.x) + _input.y;
            else _speed = Mathf.Abs(_input.x) + Mathf.Abs(_input.y);

            _speed = Mathf.Clamp(_speed, 0f, 1f);
            _speed = Mathf.SmoothDamp(current: _anim.GetFloat("Speed"), target: _speed, currentVelocity: ref _velocity,
                smoothTime: 0.1f);
            _anim.SetFloat("Speed", _speed);

            if (_input.y < 0f && KeepDirection) _direction = _input.y;
            else _direction = 0f;

            _anim.SetFloat("Direction", _direction);


            // set sprinting
            if ((Input.GetKeyDown(SprintJoystick) || Input.GetKeyDown(SprintKeyboard)) && _input != Vector2.zero &&
                _direction >= 0f) _isSprinting = true;
            if (Input.GetKeyUp(SprintJoystick) || Input.GetKeyUp(SprintKeyboard) || _input == Vector2.zero)
                _isSprinting = false;
            _anim.SetBool("isSprinting", _isSprinting);

            // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
            UpdateTargetDirection();
            if (_input != Vector2.zero && _targetDirection.magnitude > 0.1f)
            {
                var lookDirection = _targetDirection.normalized;
                _freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
                var diferenceRotation = _freeRotation.eulerAngles.y - transform.eulerAngles.y;
                var eulerY = transform.eulerAngles.y;

                if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = _freeRotation.eulerAngles.y;
                var euler = new Vector3(0, eulerY, 0);

                transform.rotation = Quaternion.Slerp(transform.rotation, b: Quaternion.Euler(euler),
                    t: TurnSpeed * _turnSpeedMultiplier * Time.deltaTime);
            }
        }

        public virtual void UpdateTargetDirection()
        {
            if (!KeepDirection)
            {
                _turnSpeedMultiplier = 1f;
                var forward = _mainCamera.transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = _mainCamera.transform.TransformDirection(Vector3.right);

                // determine the direction the player will face based on input and the referenceTransform's right and forward directions
                _targetDirection = _input.x * right + _input.y * forward;
            }
            else
            {
                _turnSpeedMultiplier = 0.2f;
                var forward = transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = transform.TransformDirection(Vector3.right);
                _targetDirection = _input.x * right + Mathf.Abs(_input.y) * forward;
            }
        }
    }
}