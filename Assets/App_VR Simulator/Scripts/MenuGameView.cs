using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameView : View {
    [SerializeField] private Button buttonMenu;
    [SerializeField] private Button buttonLobby;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private GameObject content;
    [SerializeField] private SmoothFollowPlayer smoothFollowPlayer;
    
    public event Action LobbyEvent, RestartEvent;
    
    public void Initialize(Transform camera) {
        smoothFollowPlayer.SetCamera(camera);
        Show();
        content.SetActive(false);
        Subscription();
    }
    
    private void OnMenuClick() {
        bool isActive = content.activeSelf;
        content.SetActive(!isActive);
    }
    
    private void OnLobbyClick() {
        LobbyEvent?.Invoke();
    }

    private void OnRestartClick() {
        RestartEvent?.Invoke();
    }
    
    private void Subscription() {
        buttonMenu.onClick.AddListener(OnMenuClick);
        buttonLobby.onClick.AddListener(OnLobbyClick);
        buttonRestart.onClick.AddListener(OnRestartClick);
    }

    private void UnSubscription() {
        buttonMenu.onClick.RemoveAllListeners();
        buttonLobby.onClick.RemoveAllListeners();
        buttonRestart.onClick.RemoveAllListeners();
    }

    private void OnDestroy() {
        UnSubscription();
    }

}
