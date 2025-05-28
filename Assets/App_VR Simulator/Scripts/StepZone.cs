using System;
using UnityEngine;

public class StepZone : StepAction {
    private void OnTriggerEnter(Collider other) {
        OnStepAction();
    }
    
}
