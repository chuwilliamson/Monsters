using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AIE
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float max_speed = 2.0f;
        private Animator m_anim;
        private Camera m_relativeCamera;

        // Use this for initialization
        void Start()
        {
            m_relativeCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            // Calculate the move vector relative to camera rotation
            Vector3 scalerVector = new Vector3(1f, 0f, 1f);
            Vector3 cameraForward = Vector3.Scale(m_relativeCamera.transform.forward, scalerVector).normalized;
            Vector3 cameraRight = Vector3.Scale(m_relativeCamera.transform.right, scalerVector).normalized;

            var move = (cameraForward * v + cameraRight * h);
            var velocity = move * max_speed;
            transform.position += velocity * Time.deltaTime;

            if (PlayerInput.RightTriggerGreaterZero)
            {
                Debug.Log("Fire");
            }
        }
    }

    public class PlayerInput
    {
        public static bool RightTriggerGreaterZero
        {
            get
            {
                return Input.GetAxis("RightTrigger") > 0;
            }
        }
    }
}