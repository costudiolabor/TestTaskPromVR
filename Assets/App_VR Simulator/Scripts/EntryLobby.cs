using System;
using UnityEngine;

public class EntryLobby : MonoBehaviour {
    [SerializeField] private ScenesHandler scenesHandler;
    [SerializeField] private  MenuHandler menuHandler;
    
    private void Start() {
        Initialize();
    }

    private void Initialize() {
        menuHandler.Initialize();
        Subscription();
    }
    private void Update() {
        
    }
    
    private void OnClickStart() {
        Debug.Log("OnClickStart");
        scenesHandler.LoadMainScene();
    }

    private void Subscription() {
        menuHandler.StartEvent += OnClickStart;
    }
    
    private void UnSubscription() {
        menuHandler.UnSubscription();
    }

    private void OnDestroy() {
        UnSubscription();
    }
}
