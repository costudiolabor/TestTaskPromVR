using UnityEngine;

public class EntryMain : MonoBehaviour {
    [SerializeField] private ScenesHandler scenesHandler;
    [SerializeField] private TaskHandler taskHandler;
    
    private void Start() { Initialize(); }

    private void Initialize() {
        taskHandler.Initialize();
        Subscription();
    }
    
    private void Update() {
        
    }
    
    private void OnClickStart() {
        scenesHandler.LoadScene();
    }

    private void Subscription() {
        
    }
    
    private void UnSubscription() {
        
    }

    private void OnDestroy() { UnSubscription(); }
}
