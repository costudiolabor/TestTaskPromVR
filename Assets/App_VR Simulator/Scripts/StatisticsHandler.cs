using UnityEngine;
using System;

[Serializable]
public class StatisticsHandler {
    private Group[] _groups;
    private Factory _factory;
    private Transform _parent;
    private PanelStatistics _panel;
    private NameGroup _prefabNameGroup;
    private ItemStep _prefabItemStep;
    
    public event Action LobbyEvent, RestartEvent;
    
    public void Initialize(Factory factory, PrefabsUI prefabsUI, Group[] groups, Transform camera) {
        _factory = factory;
        _prefabNameGroup = prefabsUI.PrefabNameGroup;
        _prefabItemStep = prefabsUI.PrefabItemStep;
        _panel = GetPanel(prefabsUI.PrefabPanelStatistics);
        _panel.Initialize(camera);
        _groups = groups;
        _parent = _panel.GetParent();
        _panel.Hide();
        Subscription();
    }

    private PanelStatistics GetPanel(PanelStatistics prefab) {
        return _factory.Get(prefab, null);
    }
    
    public void ShowStatistics() {
        CreateGroup();
        _panel.Show();
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
        return _factory.Get(_prefabNameGroup, _parent);
    }
    
    private ItemStep CreateItemStep() {
        return _factory.Get(_prefabItemStep, _parent);
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
    
    private void OnLobbyClick() {
        LobbyEvent?.Invoke();
    }

    private void OnRestartClck() {
        RestartEvent?.Invoke();
    }

    
    private void Subscription() {
        _panel.LobbyEvent += OnLobbyClick;
        _panel.RestartEvent += OnRestartClck;
    }

    public void UnSubscription() {
        _panel.LobbyEvent -= OnLobbyClick;
        _panel.RestartEvent -= OnRestartClck;
    }
    
}
