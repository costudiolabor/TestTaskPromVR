using UnityEngine;
using UnityEngine.UI;

public class NameGroup : MonoBehaviour {
    [SerializeField] private Text nameGroup;
    
    public void SetName(string newName) => nameGroup.text = newName;
    
}
