using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : View {
    [SerializeField] private Button buttonStart;

    public event Action StartEvent;
    public void Initialize() {
        Subscription();
    }

    private void OnClickStart() {
        StartEvent?.Invoke();
    }
    
    private void Subscription() {
        buttonStart.onClick.AddListener(OnClickStart);
    }
    
    private void UnSubscription() {
        buttonStart.onClick.RemoveAllListeners();
    }

    private void OnDestroy() {
        UnSubscription();
    }
    
}
