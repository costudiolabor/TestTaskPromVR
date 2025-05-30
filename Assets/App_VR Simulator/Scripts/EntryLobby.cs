using UnityEngine;

public class EntryLobby : MonoBehaviour {
    [SerializeField] private SettingScenes settingScenes;
    [SerializeField] private PrefabsUI prefabsUI;
    [SerializeField] private Prefabs prefabs;
    
    private ScenesHandler _scenesHandler;
    private PlayerHandler _playerHandler;
    private MenuLobbyHandler _menuLobbyHandler;
    private Factory _factory;
    private Transform _cameraTransform;
    private Player player; 
    
    private void Awake() {
        Initialize();
    }

    private void Initialize() {
        _factory = new Factory();
        _playerHandler = new PlayerHandler();
        _scenesHandler = new ScenesHandler(settingScenes);
        player = _playerHandler.GetPlayer(_factory, prefabs.Player);
        _cameraTransform = _playerHandler.GetCamera();
        
        _menuLobbyHandler = new MenuLobbyHandler();
        _menuLobbyHandler.CreateView(_factory, prefabsUI.PrefabMenuLobby);
        _menuLobbyHandler.Initialize(_cameraTransform);
        Subscription();
    }
    
    private void OnClickStart() {
        _scenesHandler.LoadMain();
    }

    private void Subscription() {
        _menuLobbyHandler.StartEvent += OnClickStart;
    }
    
    private void UnSubscription() {
        _menuLobbyHandler.UnSubscription();
    }

    private void OnDestroy() {
        UnSubscription();
    }
}
