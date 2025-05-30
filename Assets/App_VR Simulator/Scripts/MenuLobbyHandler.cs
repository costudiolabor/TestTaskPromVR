using System;
using UnityEngine;

[Serializable]
public class MenuLobbyHandler {
    private MenuLobbyView _menuLobbyView;
    public event Action StartEvent;
    public void CreateView(Factory factory, MenuLobbyView prefab) {
        _menuLobbyView = factory.Get(prefab, null);
    }

    public void Initialize(Transform camera) {
        _menuLobbyView.Initialize(camera);
        Subscription();
    }

    private void OnClickStart() {
        StartEvent?.Invoke();
    }
    
    
    private void Subscription() {
        _menuLobbyView.StartEvent += OnClickStart;
    }
    
    public void UnSubscription() {
        _menuLobbyView.StartEvent -= OnClickStart;
    }

}
