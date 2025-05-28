using UnityEngine;

public class EntryMain : MonoBehaviour {
    [SerializeField] private ScenesHandler scenesHandler;
    [SerializeField] private MenuHandler menuHandler;
    [SerializeField] private Tasks tasks;
    [SerializeField] private TaskHandler taskHandler;
    [SerializeField] private GroupHandler groupHandler;
    [SerializeField] private SoundHandler soundHandler;
    
    private void Start() { Initialize(); }

    private void Initialize() {
        menuHandler.Initialize();
        taskHandler = new TaskHandler(tasks);
        Group[] groups = taskHandler.GetGroups();
        groupHandler.Initialize();
        groupHandler.SetGroups(groups);
        groupHandler.SetupGroups();
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

    private void Subscription() {
        menuHandler.StartEvent += OnClickStart;
        taskHandler.StepEvent += OnStepAction;
        groupHandler.CorrectEvent += OnCorrectAction;
        groupHandler.InCorrectEvent += OnInCorrectAction;
    }

    private void UnSubscription() {
        menuHandler.UnSubscription();
        taskHandler.StepEvent -= OnStepAction;
        groupHandler.CorrectEvent -= OnCorrectAction;
        groupHandler.InCorrectEvent -= OnInCorrectAction;
    }

  

    private void OnDestroy() { UnSubscription(); }
}
