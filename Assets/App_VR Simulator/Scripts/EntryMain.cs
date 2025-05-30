using System.Collections;
using UnityEngine;

public class EntryMain : MonoBehaviour {
    [SerializeField] private SettingScenes settingScenes;
    [SerializeField] private AudioResources audioResources;
    [SerializeField] private PrefabsUI prefabsUI;
    [SerializeField] private Prefabs prefabs;
    [SerializeField] private Tasks tasks;
    [SerializeField] private AudioSource audioSource;
    
    
    private MenuGameHandler _menuGameHandler;
    private TaskHandler _taskHandler;
    private GroupHandler _groupHandler;
    private StatisticsHandler _statisticsHandler;
    private SoundHandler _soundHandler;
    private ScenesHandler _scenesHandler;
    private PlayerHandler _playerHandler;
    private Factory _factory;
    private Transform _cameraTransform;
    private Player _player; 

    private void Start() { Initialize(); }

    private void Initialize() {
        _factory = new Factory();
        _playerHandler = new PlayerHandler();
        _scenesHandler = new ScenesHandler(settingScenes);
        
        _player = _playerHandler.GetPlayer(_factory, prefabs.Player);
        _cameraTransform = _playerHandler.GetCamera();
        
        _menuGameHandler = new MenuGameHandler();
        _menuGameHandler.CreateView(_factory, prefabsUI.PrefabMenuGame);
        _menuGameHandler.Initialize(_cameraTransform);
        
        _taskHandler = new TaskHandler(tasks);
        _taskHandler.SetupGroups();
        Group[] groups = _taskHandler.GetGroups();
        
        _groupHandler = new GroupHandler();
        
        _groupHandler.Initialize(_factory, prefabsUI.PrefabItemStep, prefabsUI.PrefabPanelGroup, _cameraTransform);
        _groupHandler.SetGroups(groups);
        _groupHandler.SetupGroups();
        
        _statisticsHandler = new StatisticsHandler();
        _statisticsHandler.Initialize(_factory, prefabsUI, groups, _cameraTransform);
        
        _soundHandler = new SoundHandler(audioSource, audioResources);
        Subscription();
    }
    
    private void OnLobby() {
        _scenesHandler.LoadLobby();
    }

    private void OnRestart() {
        _scenesHandler.LoadMain();
    }
    
    private void OnStepAction(DataStep dataStep) {
        _groupHandler.OnStepAction(dataStep);
    }
    
    private void OnCorrectAction() {
        _soundHandler.PlayCorrect();
    }
    
    private void OnInCorrectAction() {
        _soundHandler.PlayInCorrect();
    }
    
    private void OnFinish() {
        StartCoroutine(TimerShowStatistics());
    }

    private IEnumerator TimerShowStatistics() {
        yield return new WaitForSeconds(0.5f);
        _groupHandler.HidePanelGroup();
        _statisticsHandler.ShowStatistics();
        
    }

    private void Subscription() {
        _menuGameHandler.RestartEvent += OnRestart;
        _menuGameHandler.LobbyEvent += OnLobby;
        _taskHandler.StepEvent += OnStepAction;
        _groupHandler.CorrectEvent += OnCorrectAction;
        _groupHandler.InCorrectEvent += OnInCorrectAction;
        _groupHandler.FinishEvent += OnFinish;
        _statisticsHandler.RestartEvent += OnRestart;
        _statisticsHandler.LobbyEvent += OnLobby;
    }
  
    private void UnSubscription() {
        _menuGameHandler.RestartEvent -= OnRestart;
        _menuGameHandler.LobbyEvent -= OnLobby;
        _menuGameHandler.UnSubscription();
        _taskHandler.StepEvent -= OnStepAction;
        _groupHandler.CorrectEvent -= OnCorrectAction;
        _groupHandler.InCorrectEvent -= OnInCorrectAction;
        _groupHandler.FinishEvent -= OnFinish;
        _statisticsHandler.RestartEvent -= OnRestart;
        _statisticsHandler.LobbyEvent -= OnLobby;
        _statisticsHandler.UnSubscription();
    }

    private void OnDestroy() { 
        UnSubscription();
    }
}
