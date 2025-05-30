using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuLobbyView : View {
    [SerializeField] private SmoothFollowPlayer smoothFollowPlayer;
    [SerializeField] private Button buttonStart;

    public event Action StartEvent;
    public void Initialize(Transform camera) {
        smoothFollowPlayer.SetCamera(camera);
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
