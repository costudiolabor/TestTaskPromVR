using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GroupHandler {
    [SerializeField] private PanelGroup panelGroup;
    [SerializeField] private ItemStep prefabItemStep;
    
    private List<ItemStep> _itemSteps;
    private int _currentGroup;
    private int _currentStep;
    private int _amountItem = 10;
    private Group[] _groups;
    private int _amountStepInGroup;
    private Factory _factory;
    
    public event Action CorrectEvent, InCorrectEvent, FinishEvent;
    
    public void Initialize(Factory factory) {
        _factory = factory;
        _currentGroup = 0;
        _currentStep = 0;
        CreateGroup();
        panelGroup.Show();
    }

    public void HidePanelGroup() {
        panelGroup.Hide();
    }
    
    private void CreateGroup() {
        _itemSteps = new List<ItemStep>();
        for (int i = 0; i  < _amountItem; i ++) {
            ItemStep itemStep =  CreateItem();
            _itemSteps.Add(itemStep);
        }
    }
    private ItemStep CreateItem() { return _factory.Get(prefabItemStep, panelGroup.GetParent()); }

    public void SetGroups(Group[] groups) {
        _groups = groups;
    }

    private void NextGroups() {
        _currentStep = 0;
        _currentGroup++;
        if (_currentGroup == _groups.Length) {
            FinishEvent?.Invoke();
            return;
        }
        SetupGroups();
    }
    
    public void SetupGroups() {
        SetData(_groups[_currentGroup]);
        _itemSteps[_currentStep].SetSelected(true);
    }
    
    public void SetData(Group group) {
        ResetItems();
        SetDataItems(group);
    }

    private void ResetItems() {
        for (int i = 0; i < _itemSteps.Count; i++) {
            _itemSteps[i].Reset();
            _itemSteps[i].Hide();
        }
    }
    
    private void SetDataItems(Group group) {
        string groupName = group.name;
        panelGroup.SetTitle(groupName);
        _amountStepInGroup = group.steps.Length;
        for (int i = 0; i < _amountStepInGroup; i++) {
            _itemSteps[i].SetDescription(group.steps[i].description);
            _itemSteps[i].ID = group.steps[i].ID;
            _itemSteps[i].Show();
        }
    }

    public void OnStepAction(DataStep dataStep) {
        CheckCorrectGroup(dataStep);
    }

    private void CheckCorrectGroup(DataStep dataStep) {
        int idGroup = dataStep.idGroup;
        int idStep = dataStep.idStep;
        if (idGroup == _groups[_currentGroup].ID)
            CheckCorrectStep(idStep);
        else
            OnInCorrectAction();
    }

    private void CheckCorrectStep(int idStep) {
        if (idStep == _itemSteps[_currentStep].ID) {
            OnCorrectAction();
        }
        else {
            OnInCorrectAction();
            NextGroups();
        }
    }    
    
    private void OnCorrectAction() {
        CorrectEvent?.Invoke();
        SetStateTaskAndStep(true);
        // _itemSteps[_currentStep].SetState(true);
        // SetStateInTasks(_groups[_currentGroup].steps[_currentStep], true);
        // _itemSteps[_currentStep].SetSelected(false);
        // _currentStep++;
        // if (_currentStep == _amountStepInGroup) {
        //     NextGroups();
        //     return;
        // }
        // _itemSteps[_currentStep].SetSelected(true);
    }
    
    private void OnInCorrectAction() {
        InCorrectEvent?.Invoke();
        SetStateTaskAndStep(false);
        // _itemSteps[_currentStep].SetState(false);
        // SetStateInTasks(_groups[_currentGroup].steps[_currentStep], false);
        // _itemSteps[_currentStep].SetSelected(false);
        // _currentStep++;
        // if (_currentStep == _amountStepInGroup) {
        //     NextGroups();
        //     return;
        // }
        // _itemSteps[_currentStep].SetSelected(true);
    }

    private void SetStateTaskAndStep(bool state) {
        _itemSteps[_currentStep].SetState(state);
        SetStateInTasks(_groups[_currentGroup].steps[_currentStep], state);
        _itemSteps[_currentStep].SetSelected(false);
        _currentStep++;
        if (_currentStep == _amountStepInGroup) {
            NextGroups();
            return;
        }
        _itemSteps[_currentStep].SetSelected(true);
    }
    
    private void SetStateInTasks(Step step, bool stateStep) {
        if (stateStep) step.State = StateStep.Done;
        else
            step.State = StateStep.NotDone;
    }
    
}
