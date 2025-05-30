using UnityEngine;

public class PanelStatistics : View {
    [SerializeField] private Transform content;
    [SerializeField] private SmoothFollowPlayer smoothFollowPlayer;

    public void Initialize(Transform camera) {
        smoothFollowPlayer.SetCamera(camera);
    }

    public Transform GetParent() => content;
}
