using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// Blend result source for blending.   This exposes a CinemachineBlend object
    /// as an ersatz virtual camera for the purposes of blending.  This achieves the purpose
    /// of blending the result oif a blend.
    /// </summary>
    internal class BlendSourceVirtualCamera : ICinemachineCamera
    {
        public BlendSourceVirtualCamera(CinemachineBlend blend, float deltaTime)
        {
            Blend = blend;
            UpdateCameraState(blend.CamA.State.ReferenceUp, deltaTime);
        }

        public CinemachineBlend Blend { get; private set; }

        public string Name { get { return "Blend"; }}
        public string Description { get { return Blend.Description; }}
        public int Priority { get; set; }
        public Transform LookAt { get; set; }
        public Transform Follow { get; set; }
        public CameraState State { get; private set; }
        public GameObject VirtualCameraGameObject { get { return null; } }
        public ICinemachineCamera LiveChildOrSelf { get { return Blend.CamB; } }
        public ICinemachineCamera ParentCamera { get { return null; } }
        public bool IsLiveChild(ICinemachineCamera vcam) { return vcam == Blend.CamA || vcam == Blend.CamB; }
        public CameraState CalculateNewState(float deltaTime) { return State; }
        public void UpdateCameraState(Vector3 worldUp, float deltaTime)
        {
            Blend.UpdateCameraState(worldUp, deltaTime);
            State = Blend.State;
        }
        public void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime) {}
    }
}