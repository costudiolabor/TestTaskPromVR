using System.Collections;
using UnityEngine;

public class EntryMain : MonoBehaviour {
    [SerializeField] private ScenesHandler scenesHandler;
    [SerializeField] private MenuHandler menuHandler;
    [SerializeField] private Tasks tasks;
    [SerializeField] private TaskHandler taskHandler;
    [SerializeField] private GroupHandler groupHandler;
    [SerializeField] private SoundHandler soundHandler;
    [SerializeField] private StatisticsHandler statisticsHandler;
    
    [SerializeField] private Factory _factory;

    private void Start() { Initialize(); }

    private void Initialize() {
        _factory = new Factory();
        menuHandler.Initialize();
        
        taskHandler = new TaskHandler(tasks);
        taskHandler.SetupGroups();
        Group[] groups = taskHandler.GetGroups();
        
        groupHandler.Initialize(_factory);
        groupHandler.SetGroups(groups);
        groupHandler.SetupGroups();
        
        statisticsHandler.Initialize(_factory, groups);
        Subscription();
    }
    
    private void OnClickStart() {
        scenesHandler.LoadScene();
    }
    
    private void OnStepAction(DataStep dataStep) {
        groupHandler.OnStepAction(dataStep);
    }
    
    private void OnCorrectAction() {
        soundHandler.PlayCorrect();
    }
    
    private void OnInCorrectAction() {
        soundHandler.PlayInCorrect();
    }
    
    private void OnFinish() {
        //UnSubscription();
        // statisticsHandler.ShowStatistics();
        // groupHandler.HidePanelGroup();
        StartCoroutine(TimerShowStatistics());
    }

    private IEnumerator TimerShowStatistics() {
        yield return new WaitForSeconds(0.5f);
        groupHandler.HidePanelGroup();
        statisticsHandler.ShowStatistics();
        
    }

    private void Subscription() {
        menuHandler.StartEvent += OnClickStart;
        taskHandler.StepEvent += OnStepAction;
        groupHandler.CorrectEvent += OnCorrectAction;
        groupHandler.InCorrectEvent += OnInCorrectAction;
        groupHandler.FinishEvent += OnFinish;
    }
  
    private void UnSubscription() {
        menuHandler.UnSubscription();
        taskHandler.StepEvent -= OnStepAction;
        groupHandler.CorrectEvent -= OnCorrectAction;
        groupHandler.InCorrectEvent -= OnInCorrectAction;
        groupHandler.FinishEvent -= OnFinish;
    }

    private void OnDestroy() { UnSubscription(); }
}
