using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class ScenesHandler {
    [SerializeField] private int numberMainScene;
    public void LoadScene() {
        SceneManager.LoadScene(numberMainScene);
    }
}
