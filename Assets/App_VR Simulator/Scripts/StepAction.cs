using System;
using UnityEngine;

public abstract class StepAction : MonoBehaviour{
    private DataStep _dataStep;
    
    public event Action<DataStep>  StepEvent;
    private bool _isDone = false;

    public virtual void Initialize(DataStep dataStep) {
        _dataStep = dataStep;
    }

    protected void OnStepAction() {
        if (_isDone) return;
        _isDone = true;
        StepEvent?.Invoke(_dataStep);
    }

    private void OnDestroy() {
        StepEvent = null;
    }
}