using UnityEngine;
using UnityEngine.UI;

public class ItemStep : View {
    [SerializeField] private Image imageSelected;
    [SerializeField] private Image imageState;
    [SerializeField] private Text textDescription;
    [SerializeField] private Color colorDone = Color.green;
    [SerializeField] private Color colorNotDone = Color.red;
    
    private readonly Color _resetColor = Color.white;
    private int _id;
    public int ID {
        get => _id;
        set => _id = value;
    }

    public void Reset() {
        imageState.color = _resetColor;
        bool selected = false;
        SetSelected(selected);
    }

    public void SetSelected(bool selected) {
        imageSelected.enabled = selected;
    }
    
    public void SetDescription(string description) {
        textDescription.text = description;
    }
    
    public void SetState(bool isDone) {
        if (isDone) imageState.color = colorDone;
        else imageState.color = colorNotDone;
    }
    
    
}
