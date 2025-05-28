using System;
using UnityEngine;
using UnityEngine.UI;

public class StepButton : StepAction {
    [SerializeField] private Button button;

    public override void Initialize(DataStep dataStep) {
        button.onClick.AddListener(OnClick);
        base.Initialize(dataStep);
    }

    private void OnClick() { OnStepAction(); }

    private void OnDestroy() { button.onClick.RemoveAllListeners(); }
}
