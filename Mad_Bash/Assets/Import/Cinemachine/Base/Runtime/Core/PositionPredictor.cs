using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine.Utility
{
    internal class PositionPredictor
    {
        Vector3 m_Position;

        const float kSmoothingDefault = 10;
        float mSmoothing = kSmoothingDefault;
        public float Smoothing 
        {
            get { return mSmoothing; }
            set 
            {
                if (value != mSmoothing)
                {
                    mSmoothing = value;
                    int maxRadius = Mathf.Max(10, Mathf.FloorToInt(value * 1.5f));
                    m_Velocity = new GaussianWindow1D_Vector3(mSmoothing, maxRadius);
                    m_Accel = new GaussianWindow1D_Vector3(mSmoothing, maxRadius);
                }
            }
        }

        GaussianWindow1D_Vector3 m_Velocity = new GaussianWindow1D_Vector3(kSmoothingDefault);
        GaussianWindow1D_Vector3 m_Accel = new GaussianWindow1D_Vector3(kSmoothingDefault);

        public bool IsEmpty { get { return m_Velocity.IsEmpty(); } }

        public void Reset()
        {
            m_Velocity.Reset();
            m_Accel.Reset();
        }

        public void AddPosition(Vector3 pos)
        {
            if (IsEmpty)
                m_Velocity.AddValue(Vector3.zero);
            else
            {
                Vector3 vel = m_Velocity.Value();
                Vector3 vel2 = (pos - m_Position) / Time.deltaTime;
                m_Velocity.AddValue(vel2);
                m_Accel.AddValue(vel2 - vel);
            }
            m_Position = pos;
        }

        public Vector3 PredictPosition(float lookaheadTime)
        {
            int numSteps = Mathf.Min(Mathf.RoundToInt(lookaheadTime / Time.deltaTime), 6);
            float dt = lookaheadTime / numSteps;
            Vector3 pos = m_Position;
            Vector3 vel = m_Velocity.IsEmpty() ? Vector3.zero : m_Velocity.Value();
            Vector3 accel = m_Accel.IsEmpty() ? Vector3.zero : m_Accel.Value();
            for (int i = 0; i < numSteps; ++i)
            {
                pos += vel * dt;
                Vector3 vel2 = vel + (accel * dt);
                accel = Quaternion.FromToRotation(vel, vel2) * accel;
                vel = vel2;
            }
            return pos;
        }
    }
}
