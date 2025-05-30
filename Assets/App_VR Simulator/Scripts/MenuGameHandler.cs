using System;
using UnityEngine;

[Serializable]
public class MenuGameHandler {
    private MenuGameView _menuGameView;
    
    public event Action LobbyEvent, RestartEvent;
    
    public void CreateView(Factory factory, MenuGameView prefab) {
        _menuGameView = factory.Get(prefab, null);
    }

    public void Initialize(Transform camera) {
        _menuGameView.Initialize(camera);
        Subscription();
    }
    
    private void OnLobbyClick() {
        LobbyEvent?.Invoke();
    }

    private void OnRestartClck() {
        RestartEvent?.Invoke();
    }
    
    private void Subscription() {
        _menuGameView.LobbyEvent += OnLobbyClick;
        _menuGameView.RestartEvent += OnRestartClck;
    }

    public void UnSubscription() {
      _menuGameView.LobbyEvent -= OnLobbyClick;
      _menuGameView.RestartEvent -= OnRestartClck;
    }
}
