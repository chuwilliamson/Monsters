using System;
using UnityEngine;

namespace Cinemachine.Utility
{
    internal abstract class GaussianWindow1d<T>
    {
        protected T[] mData;
        protected float[] mKernel;
        protected float mKernelSum;
        protected int mCurrentPos;

        public float Sigma { get; private set; }   // Filter strength: bigger numbers are stronger.  0.5 is minimal.
        public int KernelSize { get { return mKernel.Length; } }

        void GenerateKernel(float sigma, int maxKernelRadius)
        {
            // Weight is close to 0 at a distance of sigma*3, so let's just cut it off a little early
            int kernelRadius = Math.Min(maxKernelRadius, Mathf.FloorToInt(Mathf.Abs(sigma) * 2.5f));
            mKernel = new float[2 * kernelRadius + 1];
            mKernelSum = 0;
            if (kernelRadius == 0)
                mKernelSum = mKernel[0] = 1;
            else for (int i = -kernelRadius; i <= kernelRadius; ++i)
            {
                mKernel[i + kernelRadius]
                    = (float)(Math.Exp(-(i * i) / (2 * sigma * sigma)) / Math.Sqrt(2.0 * Math.PI * sigma));
                mKernelSum += mKernel[i + kernelRadius];
            }
            Sigma = sigma;
        }

        protected abstract T Compute(int windowPos);

        public GaussianWindow1d(float sigma, int maxKernelRadius = 10)
        {
            GenerateKernel(sigma, maxKernelRadius);
            mCurrentPos = 0;
        }

        public void Reset() { mData = null; }

        public bool IsEmpty() { return mData == null; }

        public void AddValue(T v)
        {
            if (mData == null)
            {
                mData = new T[KernelSize];
                for (int i = 0; i < KernelSize; ++i)
                    mData[i] = v;
                mCurrentPos = Mathf.Min(1, KernelSize-1);
            }
            mData[mCurrentPos] = v;
            if (++mCurrentPos == KernelSize)
                mCurrentPos = 0;
        }

        public T Filter(T v)
        {
            if (KernelSize < 3)
                return v;
            AddValue(v);
            return Value();    
        }

        /// Returned value will be kernelRadius old
        public T Value() { return Compute(mCurrentPos); }
    }
}
