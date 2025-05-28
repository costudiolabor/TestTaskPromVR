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
    public int id;
    public Step[] steps;
}

[Serializable]
public class Step {
    public string description;
    public int id;
    public string expectedAction;
    [FormerlySerializedAs("targetObj")] public StepAction targetAction;
}