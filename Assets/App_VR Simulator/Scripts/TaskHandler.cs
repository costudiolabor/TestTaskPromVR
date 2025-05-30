using System;

[Serializable]
public class TaskHandler {
    public event Action<DataStep>  StepEvent;
    private Tasks _tasks;
    
    public TaskHandler(Tasks tasks) {
        _tasks = tasks;
    }

    public void SetupGroups() {
        int amountGroups = _tasks.groups.Length;
        for (int i = 0; i  < amountGroups; i ++) {
            int idGroup = i + 1;
            _tasks.groups[i].ID = idGroup;
            SetupSteps(_tasks.groups[i]);
        }
    }

    private void SetupSteps(Group group) {
        int amountSteps = group.steps.Length;
        for (int i = 0; i  < amountSteps; i ++) {
            int idStep = i + 1;
            group.steps[i].ID = idStep;
            DataStep dataStep = new DataStep() {
                idGroup = group.ID,
                idStep = idStep
            };

            group.steps[i].targetAction.Initialize(dataStep);
            group.steps[i].targetAction.StepEvent += OnStepAction;
        }
    }
    
    private void OnStepAction(DataStep dataStep) {
        StepEvent?.Invoke(dataStep);
    }

    public Group[] GetGroups() => _tasks.groups;
}
