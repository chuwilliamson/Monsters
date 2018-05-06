using System;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>Definition of a Camera blend.  This struct holds the information
    /// necessary to generate a suitable AnimationCurve for a Cinemachine Blend.</summary>
    [Serializable]
    [DocumentationSorting(10.2f, DocumentationSortingAttribute.Level.UserRef)]
    public struct CinemachineBlendDefinition
    {
        /// <summary>Supported predefined shapes for the blend curve.</summary>
        [DocumentationSorting(10.21f, DocumentationSortingAttribute.Level.UserRef)]
        public enum Style
        {
            /// <summary>Zero-length blend</summary>
            Cut,
            /// <summary>S-shaped curve, giving a gentle and smooth transition</summary>
            EaseInOut,
            /// <summary>Linear out of the outgoing shot, and easy into the incoming</summary>
            EaseIn,
            /// <summary>Easy out of the outgoing shot, and linear into the incoming</summary>
            EaseOut,
            /// <summary>Easy out of the outgoing, and hard into the incoming</summary>
            HardIn,
            /// <summary>Hard out of the outgoing, and easy into the incoming</summary>
            HardOut,
            /// <summary>Linear blend.  Mechanical-looking.</summary>
            Linear
        };

        /// <summary>The shape of the blend curve.</summary>
        [Tooltip("Shape of the blend curve")]
        public Style m_Style;

        /// <summary>The duration (in seconds) of the blend</summary>
        [Tooltip("Duration of the blend, in seconds")]
        public float m_Time;

        /// <summary>Constructor</summary>
        /// <param name="style">The shape of the blend curve.</param>
        /// <param name="time">The duration (in seconds) of the blend</param>
        public CinemachineBlendDefinition(Style style, float time)
        {
            m_Style = style;
            m_Time = time;
        }

        /// <summary>
        /// An AnimationCurve specifying the interpolation duration and value
        /// for this camera blend. The time of the last key frame is assumed to the be the
        /// duration of the blend. Y-axis values must be in range [0,1] (internally clamped
        /// within Blender) and time must be in range of [0, +infinity)
        /// </summary>
        public AnimationCurve BlendCurve
        {
            get
            {
                float time = Mathf.Max(0, m_Time);
                switch (m_Style)
                {
                    default:
                    case Style.Cut: return new AnimationCurve();
                    case Style.EaseInOut: return AnimationCurve.EaseInOut(0f, 0f, time, 1f);
                    case Style.EaseIn:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[1].inTangent = 0;
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.EaseOut:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[0].outTangent = 0;
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.HardIn:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[0].outTangent = 0;
                        keys[1].inTangent = 1.5708f; // pi/2 = up
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.HardOut:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[0].outTangent = 1.5708f; // pi/2 = up
                        keys[1].inTangent = 0;
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.Linear: return AnimationCurve.Linear(0f, 0f, time, 1f);
                }
            }
        }
    }
}