using UnityEngine;

namespace Cinemachine.Utility
{
    internal class GaussianWindow1D_CameraRotation : GaussianWindow1d<Vector2>
    {
        public GaussianWindow1D_CameraRotation(float sigma, int maxKernelRadius = 10)
            : base(sigma, maxKernelRadius) {}

        protected override Vector2 Compute(int windowPos)
        {
            Vector2 sum = Vector2.zero;
            Vector2 v = mData[mCurrentPos];
            for (int i = 0; i < KernelSize; ++i)
            {
                Vector2 v2 = mData[windowPos] - v;
                if (v2.y > 180f)
                    v2.y -= 360f;
                if (v2.y < -180f)
                    v2.y += 360f;
                sum += v2 * mKernel[i];
                if (++windowPos == KernelSize)
                    windowPos = 0;
            }
            return v + (sum / mKernelSum);
        }
    }
}