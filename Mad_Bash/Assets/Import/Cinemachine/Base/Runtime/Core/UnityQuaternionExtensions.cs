using UnityEngine;

namespace Cinemachine.Utility
{
    /// <summary>Extentions to the Quaternion class, usen in various places by Cinemachine</summary>
    public static class UnityQuaternionExtensions
    {
        /// <summary>This is a slerp that mimics a camera operator's movement in that
        /// it chooses a path that avoids the lower hemisphere, as defined by
        /// the up param</summary>
        /// <param name="qA">First direction</param>
        /// <param name="qB">Second direction</param>
        /// <param name="t">Interpolation amoun t</param>
        /// <param name="up">Defines the up direction</param>
        public static Quaternion SlerpWithReferenceUp(
            Quaternion qA, Quaternion qB, float t, Vector3 up)
        {
            Vector3 dirA = (qA * Vector3.forward).ProjectOntoPlane(up);
            Vector3 dirB = (qB * Vector3.forward).ProjectOntoPlane(up);
            if (dirA.AlmostZero() || dirB.AlmostZero())
                return Quaternion.Slerp(qA, qB, t);

            // Work on the plane, in eulers
            Quaternion qBase = Quaternion.LookRotation(dirA, up);
            Quaternion qA1 = Quaternion.Inverse(qBase) * qA;
            Quaternion qB1 = Quaternion.Inverse(qBase) * qB;
            Vector3 eA = qA1.eulerAngles;
            Vector3 eB = qB1.eulerAngles;
            return qBase * Quaternion.Euler(
                       Mathf.LerpAngle(eA.x, eB.x, t),
                       Mathf.LerpAngle(eA.y, eB.y, t),
                       Mathf.LerpAngle(eA.z, eB.z, t));
        }

        /// <summary>Normalize a quaternion</summary>
        /// <param name="q"></param>
        /// <returns>The normalized quaternion.  Unit length is 1.</returns>
        public static Quaternion Normalized(this Quaternion q)
        {
            Vector4 v = new Vector4(q.x, q.y, q.z, q.w).normalized;
            return new Quaternion(v.x, v.y, v.z, v.w);
        }

        /// <summary>
        /// Get the rotations, first about world up, then about (travelling) local right,
        /// necessary to align the quaternion's forward with the target direction.
        /// This represents the tripod head movement needed to look at the target.
        /// This formulation makes it easy to interpolate without introducing spurious roll.
        /// </summary>
        /// <param name="orient"></param>
        /// <param name="lookAtDir">The worldspace target direction in which we want to look</param>
        /// <param name="worldUp">Which way is up</param>
        /// <returns>Vector2.y is rotation about worldUp, and Vector2.x is second rotation,
        /// about local right.</returns>
        public static Vector2 GetCameraRotationToTarget(
            this Quaternion orient, Vector3 lookAtDir, Vector3 worldUp)
        {
            if (lookAtDir.AlmostZero())
                return Vector2.zero;  // degenerate

            // Work in local space
            Quaternion toLocal = Quaternion.Inverse(orient);
            Vector3 up = toLocal * worldUp;
            lookAtDir = toLocal * lookAtDir;

            // Align yaw based on world up
            float angleH = 0;
            {
                Vector3 targetDirH = lookAtDir.ProjectOntoPlane(up);
                if (!targetDirH.AlmostZero())
                {
                    Vector3 currentDirH = Vector3.forward.ProjectOntoPlane(up);
                    if (currentDirH.AlmostZero())
                    {
                        // We're looking at the north or south pole
                        if (Vector3.Dot(currentDirH, up) > 0)
                            currentDirH = Vector3.down.ProjectOntoPlane(up);
                        else
                            currentDirH = Vector3.up.ProjectOntoPlane(up);
                    }
                    angleH = UnityVectorExtensions.SignedAngle(currentDirH, targetDirH, up);
                }
            }
            Quaternion q = Quaternion.AngleAxis(angleH, up);

            // Get local vertical angle
            float angleV = UnityVectorExtensions.SignedAngle(
                q * Vector3.forward, lookAtDir, q * Vector3.right);

            return new Vector2(angleV, angleH);
        }

        /// <summary>
        /// Apply rotations, first about world up, then about (travelling) local right.
        /// rot.y is rotation about worldUp, and rot.x is second rotation, about local right.
        /// </summary>
        /// <param name="orient"></param>
        /// <param name="rot">Vector2.y is rotation about worldUp, and Vector2.x is second rotation,
        /// about local right.</param>
        /// <param name="worldUp">Which way is up</param>
        public static Quaternion ApplyCameraRotation(
            this Quaternion orient, Vector2 rot, Vector3 worldUp)
        {
            Quaternion q = Quaternion.AngleAxis(rot.x, Vector3.right);
            return (Quaternion.AngleAxis(rot.y, worldUp) * orient) * q;
        }
    }
}