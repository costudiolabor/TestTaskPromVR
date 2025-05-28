using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tasks", menuName = "Scriptable Objects/Tasks")]

[Serializable]
public class Tasks : ScriptableObject {
    [SerializeField] private Group[] groups;
}

[Serializable]
public class Group {
    public string name;
    public Step[] steps;
}

[Serializable]
public class Step {
    public string description;
    public int id;
    public string expectedAction;
    public string target;
    public GameObject targetObj;
}

// {
//     "Group": "Проверка документов",
//     "Steps": 
//     [
//     {"id": 1, "description": "...", "expectedAction": "подойти", "target": "зона1"},
//     {"id": 2, "description": "...", "expectedAction": "граб", "target": "паспорт"},
//     {"id": 3, "description": "...", "expectedAction": "нажать кнопку", "target": "Подтвердить"}
//     ]
// }