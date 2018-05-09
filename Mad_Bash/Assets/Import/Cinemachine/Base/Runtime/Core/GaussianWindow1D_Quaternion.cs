using UnityEngine;

namespace Cinemachine.Utility
{
    internal class GaussianWindow1D_Quaternion : GaussianWindow1d<Quaternion>
    {
        public GaussianWindow1D_Quaternion(float sigma, int maxKernelRadius = 10)
            : base(sigma, maxKernelRadius) {}
        protected override Quaternion Compute(int windowPos)
        {
            Quaternion sum = new Quaternion(0, 0, 0, 0);
            Quaternion q = mData[mCurrentPos];
            Quaternion qInverse = Quaternion.Inverse(q);
            for (int i = 0; i < KernelSize; ++i)
            {
                // Make sure the quaternion is in the same hemisphere, or averaging won't work
                float scale = mKernel[i];
                Quaternion q2 = qInverse * mData[windowPos];
                if (Quaternion.Dot(Quaternion.identity, q2) < 0)
                    scale = -scale;
                sum.x += q2.x * scale;
                sum.y += q2.y * scale;
                sum.z += q2.z * scale;
                sum.w += q2.w * scale;

                if (++windowPos == KernelSize)
                    windowPos = 0;
            }
            return q * sum;
        }
    }
}