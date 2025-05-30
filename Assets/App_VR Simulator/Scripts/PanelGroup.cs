using UnityEngine;
using UnityEngine.UI;

public class PanelGroup : View {
    [SerializeField] private Text titleGroup;
    [SerializeField] private Transform content;
    
    [SerializeField] private SmoothFollowPlayer smoothFollowPlayer;
    public void Initialize(Transform camera) {
        smoothFollowPlayer.SetCamera(camera);
    }

    public void SetTitle(string title) => titleGroup.text = title;
    public Transform GetParent() => content;
    
}
