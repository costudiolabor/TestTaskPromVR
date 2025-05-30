using System;
using UnityEngine.SceneManagement;

[Serializable]
public class ScenesHandler {
    private SettingScenes _settingScenes;

    public ScenesHandler(SettingScenes settingScenes) {
        _settingScenes = settingScenes;
    }
    public void LoadLobby() {
        SceneManager.LoadScene(_settingScenes.LobbyScene);
    }

    public void LoadMain() {
        SceneManager.LoadScene(_settingScenes.MainScene);
    }
}
