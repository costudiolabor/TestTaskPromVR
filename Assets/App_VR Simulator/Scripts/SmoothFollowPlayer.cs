using UnityEngine;

public class SmoothFollowPlayer : MonoBehaviour {
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float followSpeed = 8f;
    [SerializeField] private Vector3 positionOffset = new Vector3(0, -0.2f, 1.2f);
    [SerializeField] private bool facePlayer = true;
    
    private void Update() {
        Vector3 targetPosition = playerCamera.position
                                 + playerCamera.forward * positionOffset.z
                                 + playerCamera.right * positionOffset.x
                                 + playerCamera.up * positionOffset.y;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        
        if (facePlayer) {
            transform.LookAt(playerCamera);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + 180, 0);
        }
    }
    
}
