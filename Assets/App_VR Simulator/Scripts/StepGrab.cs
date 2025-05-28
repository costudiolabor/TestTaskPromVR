using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class StepGrab : StepAction {
    [SerializeField] private XRGrabInteractable grabInteractable;  
    
    public override void Initialize(DataStep dataStep) {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
        base.Initialize(dataStep);
    }

    private void OnGrabbed(SelectEnterEventArgs args) {
        OnStepAction();
        //Debug.Log("Объект взят в руки!");
        // Можно получить, кто взял объект: args.interactorObject.transform
    }

    private void OnReleased(SelectExitEventArgs args) {
        //Debug.Log("Объект отпущен!");
    }

    private void OnDestroy() {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }
    
}
