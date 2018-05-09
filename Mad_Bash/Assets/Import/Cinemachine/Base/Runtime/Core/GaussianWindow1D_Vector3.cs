using UnityEngine;

namespace Cinemachine.Utility
{
    internal class GaussianWindow1D_Vector3 : GaussianWindow1d<Vector3>
    {
        public GaussianWindow1D_Vector3(float sigma, int maxKernelRadius = 10)
            : base(sigma, maxKernelRadius) {}

        protected override Vector3 Compute(int windowPos)
        {
            Vector3 sum = Vector3.zero;
            for (int i = 0; i < KernelSize; ++i)
            {
                sum += mData[windowPos] * mKernel[i];
                if (++windowPos == KernelSize)
                    windowPos = 0;
            }
            return sum / mKernelSum;
        }
    }
}