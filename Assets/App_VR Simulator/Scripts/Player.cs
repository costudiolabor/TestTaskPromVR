using Unity.XR.CoreUtils;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private Camera camera;
    
    public XROrigin XROrigin => xrOrigin;
    public Transform CameraTransform => camera.transform;
}
