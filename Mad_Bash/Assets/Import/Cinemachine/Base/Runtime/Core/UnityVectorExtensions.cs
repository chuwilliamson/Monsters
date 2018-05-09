using UnityEngine;

namespace Cinemachine.Utility
{
    /// <summary>Extensions to the Vector3 class, used by Cinemachine</summary>
    public static class UnityVectorExtensions
    {
        /// <summary>A useful Epsilon</summary>
        public const float Epsilon = 0.0001f;

        /// <summary>
        /// Get the closest point on a line segment.
        /// </summary>
        /// <param name="p">A point in space</param>
        /// <param name="s0">Start of line segment</param>
        /// <param name="s1">End of line segment</param>
        /// <returns>The interpolation parameter representing the point on the segment, with 0==s0, and 1==s1</returns>
        public static float ClosestPointOnSegment(this Vector3 p, Vector3 s0, Vector3 s1)
        {
            Vector3 s = s1 - s0;
            float len2 = Vector3.SqrMagnitude(s);
            if (len2 < Epsilon)
                return 0; // degenrate segment
            return Mathf.Clamp01(Vector3.Dot(p - s0, s) / len2);
        }

        /// <summary>
        /// Get the closest point on a line segment.
        /// </summary>
        /// <param name="p">A point in space</param>
        /// <param name="s0">Start of line segment</param>
        /// <param name="s1">End of line segment</param>
        /// <returns>The interpolation parameter representing the point on the segment, with 0==s0, and 1==s1</returns>
        public static float ClosestPointOnSegment(this Vector2 p, Vector2 s0, Vector2 s1)
        {
            Vector2 s = s1 - s0;
            float len2 = Vector2.SqrMagnitude(s);
            if (len2 < Epsilon)
                return 0; // degenrate segment
            return Mathf.Clamp01(Vector2.Dot(p - s0, s) / len2);
        }

        /// <summary>
        /// Returns a non-normalized projection of the supplied vector onto a plane
        /// as described by its normal
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="planeNormal">The normal that defines the plane.  Cannot be zero-length.</param>
        /// <returns>The component of the vector that lies in the plane</returns>
        public static Vector3 ProjectOntoPlane(this Vector3 vector, Vector3 planeNormal)
        {
            return (vector - Vector3.Dot(vector, planeNormal) * planeNormal);
        }

        /// <summary>Is the vector within Epsilon of zero length?</summary>
        /// <param name="v"></param>
        /// <returns>True if the square magnitude of the vector is within Epsilon of zero</returns>
        public static bool AlmostZero(this Vector3 v)
        {
            return v.sqrMagnitude < (Epsilon * Epsilon);
        }

        /// <summary>Get a signed angle between two vectors</summary>
        /// <param name="from">Start direction</param>
        /// <param name="to">End direction</param>
        /// <param name="refNormal">This is needed in order to determine the sign.
        /// For example, if from an to lie on the XZ plane, then this would be the
        /// Y unit vector, or indeed any vector which, when dotted with Y unit vector,
        /// would give a positive result.</param>
        /// <returns>The signed angle between the vectors</returns>
        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 refNormal)
        {
            from.Normalize();
            to.Normalize();
            float dot = Vector3.Dot(Vector3.Cross(from, to), refNormal);
            if (Mathf.Abs(dot) < -Epsilon)
                return Vector3.Dot(from, to) < 0 ? 180 : 0;
            float angle = Vector3.Angle(from, to);
            if (dot < 0)
                return -angle;
            return angle;
        }

        /// <summary>This is a slerp that mimics a camera operator's movement in that
        /// it chooses a path that avoids the lower hemisphere, as defined by
        /// the up param</summary>
        /// <param name="vA">First direction</param>
        /// <param name="vB">Second direction</param>
        /// <param name="t">Interpolation amoun t</param>
        /// <param name="up">Defines the up direction</param>
        public static Vector3 SlerpWithReferenceUp(
            Vector3 vA, Vector3 vB, float t, Vector3 up)
        {
            float dA = vA.magnitude;
            float dB = vB.magnitude;
            if (dA < Epsilon || dB < Epsilon)
                return Vector3.Lerp(vA, vB, t);

            Vector3 dirA = vA / dA;
            Vector3 dirB = vB / dB;
            Quaternion qA = Quaternion.LookRotation(dirA, up);
            Quaternion qB = Quaternion.LookRotation(dirB, up);
            Quaternion q = UnityQuaternionExtensions.SlerpWithReferenceUp(qA, qB, t, up);
            Vector3 dir = q * Vector3.forward;
            return dir * Mathf.Lerp(dA, dB, t);
        }
    }
}
