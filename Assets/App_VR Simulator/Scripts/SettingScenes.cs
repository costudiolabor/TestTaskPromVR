using UnityEngine;

[CreateAssetMenu(fileName = "SettingScenes", menuName = "Scriptable Objects/SettingScenes")]
public class SettingScenes : ScriptableObject {
    [SerializeField] private int lobbyScene;
    [SerializeField] private int mainScene;
    
    public int LobbyScene => lobbyScene;
    public int MainScene => mainScene;
}
