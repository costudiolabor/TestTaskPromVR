using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelStatistics : View {
    [SerializeField] private Button buttonLobby;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Transform content;
    [SerializeField] private SmoothFollowPlayer smoothFollowPlayer;
    
    public event Action LobbyEvent, RestartEvent;
    
    public void Initialize(Transform camera) {
        smoothFollowPlayer.SetCamera(camera);
        Subscription();
    }

    public Transform GetParent() => content;
    
    private void OnLobbyClick() {
        LobbyEvent?.Invoke();
    }

    private void OnRestartClick() {
        RestartEvent?.Invoke();
    }
    
    private void Subscription() {
        buttonLobby.onClick.AddListener(OnLobbyClick);
        buttonRestart.onClick.AddListener(OnRestartClick);
    }
    
    private void UnSubscription() {
        buttonLobby.onClick.RemoveAllListeners();
        buttonRestart.onClick.RemoveAllListeners();
    }

    private void OnDestroy() {
        UnSubscription();
    }
}
