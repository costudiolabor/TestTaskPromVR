using System.Collections.Generic;
using Object = UnityEngine.Object;
using UnityEngine;
using System;

[Serializable]
public class GroupHandler {
    [SerializeField] private PanelGroup panelGroup;
    [SerializeField] private ItemStep prefabItemStep;
    [SerializeField] private List<ItemStep> itemSteps;
    
    [SerializeField] private int currentGroup;
    [SerializeField] private int currentStep;
    
    private int _amountItem = 10;
    private Group[] _groups;
    private int _amountStepInGroup;
    public event Action CorrectEvent, InCorrectEvent;
    
    public void Initialize() {
        currentGroup = 0;
        currentStep = 0;
        CreateGroup();
    }

    private void CreateGroup() {
        itemSteps = new List<ItemStep>();
        for (int i = 0; i  < _amountItem; i ++) {
            ItemStep itemStep =  CreateItem();
            itemSteps.Add(itemStep);
        }
    }
    private ItemStep CreateItem() { return Object.Instantiate(prefabItemStep, panelGroup.GetParent()); }

    public void SetGroups(Group[] groups) {
        _groups = groups;
    }

    private void NextGroups() {
        currentStep = 0;
        currentGroup++;
        SetupGroups();
    }
    
    public void SetupGroups() {
        SetData(_groups[currentGroup]);
        itemSteps[currentStep].SetSelected(true);
    }
    
    public void SetData(Group group) {
        ResetItems();
        SetDataItems(group);
    }

    private void ResetItems() {
        for (int i = 0; i < itemSteps.Count; i++) {
            itemSteps[i].Reset();
            itemSteps[i].Hide();
        }
    }
    
    private void SetDataItems(Group group) {
        string groupName = group.name;
        panelGroup.SetTitle(groupName);
        _amountStepInGroup = group.steps.Length;
        for (int i = 0; i < _amountStepInGroup; i++) {
            itemSteps[i].SetDescription(group.steps[i].description);
            itemSteps[i].ID = group.steps[i].id;
            itemSteps[i].Show();
        }
    }

    public void OnStepAction(DataStep dataStep) {
        CheckCorrectStep(dataStep);
    }

    private void CheckCorrectStep(DataStep dataStep) {
        int idGroup = dataStep.idGroup;
        int idStep = dataStep.idStep;
        if (idGroup == _groups[currentGroup].id) {
            if (idStep == itemSteps[currentStep].ID) {
                OnCorrectAction();
            }
            else {
                OnInCorrectAction();
                NextGroups();
            }
        }
        else {
            OnInCorrectAction();
        }
        
    }
    
    private void OnCorrectAction() {
        CorrectEvent?.Invoke();
        itemSteps[currentStep].SetState(true);
        itemSteps[currentStep].SetSelected(false);
        currentStep++;
        if (currentStep == _amountStepInGroup) {
            NextGroups();
            return;
        }
        itemSteps[currentStep].SetSelected(true);
    }
    
    private void OnInCorrectAction() {
        InCorrectEvent?.Invoke();
        itemSteps[currentStep].SetState(false);
        itemSteps[currentStep].SetSelected(false);
        currentStep++;
        if (currentStep == _amountStepInGroup) {
            NextGroups();
            return;
        }
        itemSteps[currentStep].SetSelected(true);
    }
   
}
