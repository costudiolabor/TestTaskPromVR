using System;
using UnityEngine;

[Serializable]
public class MenuHandler {
    [SerializeField] private MenuView menuView;
    
    public event Action StartEvent;
    
    public void Initialize() {
        menuView.Initialize();
        Subscription();
    }

    private void OnClickStart() {
        StartEvent?.Invoke();
    }
    
    
    private void Subscription() {
        menuView.StartEvent += OnClickStart;
    }
    
    public void UnSubscription() {
        menuView.StartEvent -= OnClickStart;
    }

}
