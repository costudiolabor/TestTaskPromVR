using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class StepPokeButton : StepAction {
    [SerializeField] private XRSimpleInteractable xrSimpleInteractable;  
    
    public override void Initialize(DataStep dataStep) {
        xrSimpleInteractable.selectEntered.AddListener(OnGrabbed);
        xrSimpleInteractable.selectExited.AddListener(OnReleased);
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
        xrSimpleInteractable.selectEntered.RemoveListener(OnGrabbed);
        xrSimpleInteractable.selectExited.RemoveListener(OnReleased);
    }
}
