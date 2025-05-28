using System;
using UnityEngine;

[Serializable]
public class TaskHandler {
    [SerializeField] private Tasks tasks;
    [SerializeField] private StepAction[] stepActions;

    public void Initialize() {
        for (int i = 0; i  < stepActions.Length; i ++) {
            stepActions[i].Initialize(0);
            stepActions[i].StepEvent += OnStepAction;
        }
    }

    private void OnStepAction(int id) {
        Debug.Log("OnStepAction " + id);
    }
    
}
