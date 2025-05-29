using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Tasks : MonoBehaviour {
    public Group[] groups;
}

[Serializable]
public class Group {
    public string name;
    private int _id;
    public Step[] steps;
    public int ID {
        get => _id; 
        set => _id = value; 
    } 
}

[Serializable]
public class Step {
    public string description;
    private int _id;
    public StepAction targetAction;
    private StateStep _state;
    public int ID {
        get => _id; 
        set => _id = value; 
    } 
    
    public StateStep State {
        get => _state; 
        set => _state = value; 
    } 
}

public enum StateStep {
    Skip,
    Done,
    NotDone
}