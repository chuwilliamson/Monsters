using UnityEngine;

namespace AIE
{
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