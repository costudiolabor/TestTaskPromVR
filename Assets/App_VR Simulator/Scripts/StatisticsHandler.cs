using UnityEngine;
using System;

[Serializable]
public class StatisticsHandler {
    [SerializeField] private PanelStatistics panelStatistics;
    [SerializeField] private NameGroup prefabNameGroup;
    [SerializeField] private ItemStep prefabItemStep;
    private Group[] _groups;
    private Factory _factory;
    private Transform _parent;
    
    public void Initialize(Factory factory, Group[] groups) {
        _factory = factory;
        _groups = groups;
        _parent = panelStatistics.GetParent();
        panelStatistics.Hide();
    }

    public void ShowStatistics() {
        CreateGroup();
        panelStatistics.Show();
    }

    private void CreateGroup() {
        for (int i = 0; i  < _groups.Length; i ++) {
            
            string name = _groups[i].name;
            NameGroup nameGroup = CreateItemGroup();
            nameGroup.SetName(name);
            
            for (int j = 0; j < _groups[i].steps.Length; j++) {
                Step step = _groups[i].steps[j];
                ItemStep itemStep = CreateItemStep();
                SetupItemStep(itemStep, step);
            }
        }
    }

    private NameGroup CreateItemGroup() {
        return _factory.Get(prefabNameGroup, _parent);
    }
    
    private ItemStep CreateItemStep() {
        //return Object.Instantiate(prefabItemStep, panelStatistics.GetParent());
        return _factory.Get(prefabItemStep, _parent);
    }

    private void SetupItemStep(ItemStep itemStep, Step step) {
        itemStep.SetDescription(step.description);
        SetState(itemStep, step.State);
        itemStep.Show();
    }

    private void SetState(ItemStep itemStep, StateStep stateStep) {
        switch (stateStep) {
            case StateStep.Done:
                itemStep.SetState(true);
                
                break;
            case StateStep.NotDone:
                itemStep.SetState(false);
                break;
        }
    }
    
}
