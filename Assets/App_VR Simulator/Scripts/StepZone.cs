using UnityEngine;

public class StepZone : StepAction {
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent(out CharacterController characterController))
            OnStepAction();
    }
    
}
