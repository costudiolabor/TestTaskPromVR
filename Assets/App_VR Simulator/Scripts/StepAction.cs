using System;
using UnityEngine;

public abstract class StepAction : MonoBehaviour{
    [SerializeField] private int id;
    
    public event Action<int>  StepEvent;
    private bool _isDone = false;
    public virtual void Initialize(int id) { }

    protected void OnStepAction() {
        if (_isDone) return;
        _isDone = true;
        StepEvent?.Invoke(id);
    }
}