using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// Point source for blending. It's not really a virtual camera, but takes
    /// a CameraState and exposes it as a virtual camera for the purposes of blending.
    /// </summary>
    internal class StaticPointVirtualCamera : ICinemachineCamera
    {
        public StaticPointVirtualCamera(CameraState state, string name) { State = state; Name = name; }
        public void SetState(CameraState state) { State = state; }

        public string Name { get; private set; }
        public string Description { get { return ""; }}
        public int Priority { get; set; }
        public Transform LookAt { get; set; }
        public Transform Follow { get; set; }
        public CameraState State { get; private set; }
        public GameObject VirtualCameraGameObject { get { return null; } }
        public ICinemachineCamera LiveChildOrSelf { get { return this; } }
        public ICinemachineCamera ParentCamera { get { return null; } }
        public bool IsLiveChild(ICinemachineCamera vcam) { return false; }
        public void UpdateCameraState(Vector3 worldUp, float deltaTime) {}
        public void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime) {}
    }
}